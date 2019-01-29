#!/usr/bin/env node

const xcode = require('xcode')
const { writeFileSync } = require('fs')

const reactPath = 'node_modules/react-native/React/React.xcodeproj/project.pbxproj'
const react = xcode.project(reactPath)

// parsing is async, in a different process
react.parse((err) => {
  if (err) {
    console.log(err)
  } else {
    react.addTargetAttribute('PRODUCT_MODULE_NAME', '$(PRODUCT_NAME:c99extidentifier)-tvos', 'React-tvOS')
    writeFileSync(reactPath, react.writeSync())
  }

  // PRODUCT_MODULE_NAME = "$(PRODUCT_NAME:c99extidentifier)-tvos";
  // myProj.addHeaderFile('foo.h');
  // myProj.addSourceFile('foo.m');
  // myProj.addFramework('FooKit.framework');

  // writeFileSync(projectPath, myProj.writeSync())
})
