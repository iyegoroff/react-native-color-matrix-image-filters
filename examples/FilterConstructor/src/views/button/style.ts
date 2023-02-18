import { TextStyle, ViewStyle } from 'react-native'
import { theme } from '../theme'

const { borderRadius, primaryColor, primaryColorPressed, controlHeight } = theme

const disabledColor = 'grey'

const container: ViewStyle = {
  borderColor: primaryColor,
  borderWidth: 1,
  borderRadius,
  height: controlHeight,
  flexGrow: 1
}

const disabledContainer: ViewStyle = {
  ...container,
  borderColor: disabledColor
}

const background: ViewStyle = {
  flex: 1,
  borderRadius: borderRadius - 0.5,
  backgroundColor: 'white',
  justifyContent: 'center',
  alignItems: 'center',
  paddingHorizontal: 3
}

const pressedBackground: ViewStyle = {
  ...background,
  backgroundColor: primaryColorPressed
}

const label: TextStyle = {
  fontWeight: 'bold',
  color: primaryColor
}

const pressedLabel: TextStyle = {
  fontWeight: 'bold',
  color: 'white'
}

const disabledLabel: TextStyle = {
  fontWeight: 'bold',
  color: disabledColor
}

export const styles = {
  container,
  disabledContainer,
  background,
  label,
  disabledLabel,
  pressedLabel,
  pressedBackground
} as const
