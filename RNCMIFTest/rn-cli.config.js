const path = require('path');

const extraNodeModules = {
  'react': path.resolve(__dirname, 'node_modules/react'),
  'react-native': path.resolve(__dirname, 'node_modules/react-native'),
  'fbjs': path.resolve(__dirname, 'node_modules/fbjs'),
  '@babel/runtime': path.resolve(__dirname, 'node_modules/@babel/runtime')
};
const blacklistRegexes = [
  /[/\\]Users[/\\]iyegoroff[/\\]Documents[/\\]dev[/\\]js[/\\]react-native-color-matrix-image-filters[/\\]node_modules[/\\]react-native[/\\].*/
];
const watchFolders = [
  path.resolve('/Users/iyegoroff/Documents/dev/js/react-native-color-matrix-image-filters')
];

const metroVersion = require('metro/package.json').version;
const metroVersionComponents = metroVersion.match(/^(\d+)\.(\d+)\.(\d+)/);
if (metroVersionComponents[1] === '0' && parseInt(metroVersionComponents[2], 10) >= 43) {
    module.exports = {
      resolver: {
        extraNodeModules,
        blacklistRE: require('metro-config/src/defaults/blacklist')(blacklistRegexes)
      },
      watchFolders
    };
} else {
    module.exports = {
      extraNodeModules,
      getBlacklistRE: () => require('metro/src/blacklist')(blacklistRegexes),
      getProjectRoots: () => [path.resolve(__dirname)].concat(watchFolders)
    };
}


