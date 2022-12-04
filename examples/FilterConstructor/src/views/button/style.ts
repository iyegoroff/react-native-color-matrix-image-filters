import memoize from 'fast-memoize'
import { TextStyle, ViewStyle } from 'react-native'
import { theme } from '../theme'

const { borderRadius, primaryColor, primaryColorPressed, controlHeight } = theme

const disabledColor = 'grey'

const container: ViewStyle = {
  borderColor: primaryColor,
  borderWidth: 1,
  borderRadius,
  height: controlHeight,
  minWidth: 70
}

const disabledContainer: ViewStyle = {
  ...container,
  borderColor: disabledColor
}

const background = memoize(
  (pressed: boolean): ViewStyle => ({
    flex: 1,
    borderRadius: borderRadius - 0.5,
    backgroundColor: pressed ? primaryColorPressed : 'white',
    justifyContent: 'center',
    alignItems: 'center',
    paddingHorizontal: 3
  })
)

const disabledLabel: TextStyle = {
  fontWeight: 'bold',
  color: disabledColor
}

const label = memoize(
  (pressed: boolean): TextStyle => ({
    ...disabledLabel,
    color: pressed ? 'white' : primaryColor
  })
)

export const styles = {
  container,
  disabledContainer,
  background,
  label,
  disabledLabel
} as const
