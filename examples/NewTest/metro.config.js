const path = require('path')
const { getDefaultConfig, mergeConfig } = require('@react-native/metro-config')
const exclusionList = require('metro-config/src/defaults/exclusionList')
const escape = require('escape-string-regexp')
const pak = require('../../package.json')

const root = path.resolve(__dirname, '../..')

const modules = Object.keys({
  ...pak.peerDependencies
})

const config = {
  projectRoot: __dirname,
  watchFolders: [root],

  resolver: {
    blockList: exclusionList(
      modules.map((m) => new RegExp(`^${escape(path.join(root, 'node_modules', m))}\\/.*$`))
    ),

    extraNodeModules: modules.reduce((acc, name) => {
      acc[name] = path.join(__dirname, 'node_modules', name)
      return acc
    }, {}),

    nodeModulesPaths: [path.join(__dirname, '../../..')]
  }
}

module.exports = mergeConfig(getDefaultConfig(__dirname), config)
