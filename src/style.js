import { StyleSheet, processColor } from 'react-native'
import invariant from 'fbjs/lib/invariant'

// For some reason RNImageMatrixFilter draw method is not called when component's backgroundColor
// is not set or transparent
export const defaultStyle = StyleSheet.create({
  container: {
    backgroundColor: '#fff0'
  }
})

export const checkStyle = (style) => {
  if (style) {
    const { backgroundColor } = StyleSheet.flatten(style)

    invariant(
      processColor(backgroundColor) !== 0,
      `ImageFilter: Can't use '${backgroundColor}' backgroundColor,` +
      ' consider using \'#fff0\' instead.'
    )
  }
}
