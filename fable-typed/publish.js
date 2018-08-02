#!/usr/bin/env node

const fs = require('fs');
const { exec } = require('child_process');
const { promisify } = require('util');

const versionMatcher = /<Version>(\d+)\.(\d+)\.(\d+)<\/Version>/m;

const usage = () => {
  console.log('Usage: ./publish.js [patch|minor|major]\n');
};

const publish = async (bumpStrategy) => {
  const packageName = (await promisify(fs.readdir)('./'))
    .find(f => f.endsWith('.fsproj'))
    .replace('.fsproj', '');

  const fsprojPath = `./${packageName}.fsproj`;

  const fsproj = (await promisify(fs.readFile)(fsprojPath)).toString();

  const [, major, minor, patch] = fsproj.match(versionMatcher);

  const nextVersion = bumpStrategy === 'patch'
    ? `${major}.${minor}.${+patch + 1}`
    : bumpStrategy === 'minor'
      ? `${major}.${+minor + 1}.0`
      : `${+major + 1}.0.0`;

  const nextFsproj = fsproj.replace(versionMatcher, `<Version>${nextVersion}</Version>`);

  await promisify(fs.writeFile)(fsprojPath, nextFsproj);

  const run = exec(
    `rm -rf ./{bin,obj} &&
     dotnet pack -c Release &&
     dotnet nuget push --source nuget.org -k \${NUGET_KEY} bin/Release/${packageName}.${nextVersion}.nupkg &&
     git add -u &&
     git commit -am 'version ${nextVersion}' &&
     git push &&
     git tag 'v${nextVersion}' &&
     git push origin --tags
    `
  );

  run.stdout.pipe(process.stdout);
};

const [, , bumpStrategy] = process.argv;

if (bumpStrategy && /^(patch|minor|major)$/.test(bumpStrategy)) {
  publish(bumpStrategy);
} else {
  usage();
}
