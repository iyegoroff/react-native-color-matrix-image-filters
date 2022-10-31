import memoize from 'fast-memoize'
import { contrastColor } from 'contrast-color'
import { TextStyle, ViewStyle } from 'react-native'
import { theme } from '../theme'

const { borderRadius, primaryColor, primaryColorPressed } = theme

const auxRadius = borderRadius - 1

const container: Readonly<ViewStyle> = {
  flexDirection: 'row',
  margin: 5,
  height: 35,
  borderColor: primaryColor,
  borderWidth: 1,
  borderRadius
}

const leftItem: Readonly<ViewStyle> = {
  flex: 1,
  borderTopLeftRadius: auxRadius,
  borderBottomLeftRadius: auxRadius
}

const item: Readonly<ViewStyle> = {
  flex: 1
}

const rightItem: Readonly<ViewStyle> = {
  flex: 1,
  borderTopRightRadius: auxRadius,
  borderBottomRightRadius: auxRadius
}

const labelBackground = (pressed: boolean, selected: boolean) =>
  selected ? primaryColor : pressed ? primaryColorPressed : 'transparent'

const leftLabelContainer = memoize(
  (pressed: boolean, selected: boolean): Readonly<ViewStyle> => ({
    width: '100%',
    height: '100%',
    backgroundColor: labelBackground(pressed, selected),
    borderTopLeftRadius: auxRadius,
    borderBottomLeftRadius: auxRadius,
    justifyContent: 'center',
    alignItems: 'center'
  })
)

const middleLabelContainer = memoize(
  (pressed: boolean, selected: boolean): Readonly<ViewStyle> => ({
    width: '100%',
    height: '100%',
    backgroundColor: labelBackground(pressed, selected),
    justifyContent: 'center',
    alignItems: 'center'
  })
)

const rightLabelContainer = memoize(
  (pressed: boolean, selected: boolean): Readonly<ViewStyle> => ({
    width: '100%',
    height: '100%',
    backgroundColor: labelBackground(pressed, selected),
    borderTopRightRadius: auxRadius,
    borderBottomRightRadius: auxRadius,
    justifyContent: 'center',
    alignItems: 'center'
  })
)

const label = memoize(
  (selected: boolean): Readonly<TextStyle> => ({
    color: selected ? 'white' : primaryColor,
    fontWeight: 'bold'
  })
)

const separator: Readonly<ViewStyle> = { width: 1, height: '100%', backgroundColor: primaryColor }

const leftColorContainer = memoize(
  (pressed: boolean, color: string): Readonly<ViewStyle> => ({
    width: '100%',
    height: '100%',
    backgroundColor: color,
    opacity: pressed ? 0.5 : 1,
    borderTopLeftRadius: auxRadius,
    borderBottomLeftRadius: auxRadius,
    justifyContent: 'center',
    alignItems: 'center'
  })
)

const middleColorContainer = memoize(
  (pressed: boolean, color: string): Readonly<ViewStyle> => ({
    width: '100%',
    height: '100%',
    backgroundColor: color,
    opacity: pressed ? 0.5 : 1,
    justifyContent: 'center',
    alignItems: 'center'
  })
)

const rightColorContainer = memoize(
  (pressed: boolean, color: string): Readonly<ViewStyle> => ({
    width: '100%',
    height: '100%',
    backgroundColor: color,
    opacity: pressed ? 0.5 : 1,
    borderTopRightRadius: auxRadius,
    borderBottomRightRadius: auxRadius,
    justifyContent: 'center',
    alignItems: 'center'
  })
)

const colorMark = memoize(
  (selected: boolean, color: string): Readonly<TextStyle> => ({
    color: selected ? contrastColor({ bgColor: color }) : 'transparent'
  })
)

export const styles = {
  item: {
    left: leftItem,
    middle: item,
    right: rightItem
  },
  labelContainer: {
    left: leftLabelContainer,
    middle: middleLabelContainer,
    right: rightLabelContainer
  },
  colorContainer: {
    left: leftColorContainer,
    middle: middleColorContainer,
    right: rightColorContainer
  },
  container,
  label,
  separator,
  colorMark
}
