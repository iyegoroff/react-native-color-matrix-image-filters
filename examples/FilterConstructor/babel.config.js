module.exports = (api) =>
  api.env('test')
    ? {
        presets: ['@babel/preset-env', '@babel/preset-typescript', '@babel/preset-react'],
        targets: { node: 16 }
      }
    : {
        presets: ['module:@react-native/babel-preset']
      }
