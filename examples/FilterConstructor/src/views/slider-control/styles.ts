import { Platform, TextStyle, ViewStyle } from 'react-native'
import { theme } from '../theme'

const { borderRadius, primaryColor } = theme

const container: ViewStyle = {
  borderWidth: 1,
  borderRadius,
  borderColor: primaryColor,
  padding: 3,
  width: '100%',
  justifyContent: 'center'
}

const slider: ViewStyle = {
  height: '100%',
  width: '100%',
  position: 'absolute',
  alignSelf: 'center'
}

const label: TextStyle = {
  color: primaryColor,
  fontWeight: 'bold'
}

const name: TextStyle = {
  ...label,
  marginBottom: Platform.select({
    ios: 30,
    android: 10
  })
}

const bottom: ViewStyle = {
  flexDirection: 'row',
  justifyContent: 'space-between'
}

export const styles = {
  container,
  label,
  bottom,
  slider,
  name
} as const
