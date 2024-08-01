const path = require('path')
const { mergeConfig } = require('@react-native/metro-config')
const { getDefaultConfig } = require('expo/metro-config')
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
    }, {})
  }
}

module.exports = mergeConfig(getDefaultConfig(__dirname), config)
