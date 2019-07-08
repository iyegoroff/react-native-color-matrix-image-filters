/**
 * Metro configuration for React Native
 * https://github.com/facebook/react-native
 *
 * @format
 */

const path = require('path')

const extraNodeModules = {
  'react': path.resolve(__dirname, 'node_modules/react'),
  'fbjs': path.resolve(__dirname, 'node_modules/fbjs'),
  'react-native': path.resolve(__dirname, 'node_modules/react-native'),
  '@babel/runtime': path.resolve(__dirname, 'node_modules/@babel/runtime'),
  'react-native-color-matrix-image-filters': path.resolve(__dirname, '../')
}
const watchFolders = [
  path.resolve(__dirname, '../')
]

module.exports = {
  resolver: {
    extraNodeModules
  },
  watchFolders,
  transformer: {
    getTransformOptions: async () => ({
      transform: {
        experimentalImportSupport: false,
        inlineRequires: false
      }
    })
  }
}
