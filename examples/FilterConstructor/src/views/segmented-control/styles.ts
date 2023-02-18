import { contrastColor } from 'contrast-color'
import { TextStyle, ViewStyle } from 'react-native'
import { theme } from '../theme'

const { borderRadius, primaryColor, primaryColorPressed, controlHeight } = theme

const auxRadius = borderRadius - 1.5

const container: Readonly<ViewStyle> = {
  flexDirection: 'row',
  height: controlHeight,
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

const leftLabelContainer = (pressed: boolean, selected: boolean): Readonly<ViewStyle> => ({
  width: '100%',
  height: '100%',
  backgroundColor: labelBackground(pressed, selected),
  borderTopLeftRadius: auxRadius,
  borderBottomLeftRadius: auxRadius,
  justifyContent: 'center',
  alignItems: 'center'
})

const middleLabelContainer = (pressed: boolean, selected: boolean): Readonly<ViewStyle> => ({
  width: '100%',
  height: '100%',
  backgroundColor: labelBackground(pressed, selected),
  justifyContent: 'center',
  alignItems: 'center'
})

const rightLabelContainer = (pressed: boolean, selected: boolean): Readonly<ViewStyle> => ({
  width: '100%',
  height: '100%',
  backgroundColor: labelBackground(pressed, selected),
  borderTopRightRadius: auxRadius,
  borderBottomRightRadius: auxRadius,
  justifyContent: 'center',
  alignItems: 'center'
})

const label: Readonly<TextStyle> = {
  color: primaryColor,
  fontWeight: 'bold'
}

const selectedLabel: Readonly<TextStyle> = {
  color: 'white',
  fontWeight: 'bold'
}

const separator: Readonly<ViewStyle> = { width: 1, height: '100%', backgroundColor: primaryColor }

const leftColorContainer = (pressed: boolean, color: string): Readonly<ViewStyle> => ({
  width: '100%',
  height: '100%',
  backgroundColor: color,
  opacity: pressed ? 0.5 : 1,
  borderTopLeftRadius: auxRadius,
  borderBottomLeftRadius: auxRadius,
  justifyContent: 'center',
  alignItems: 'center'
})

const middleColorContainer = (pressed: boolean, color: string): Readonly<ViewStyle> => ({
  width: '100%',
  height: '100%',
  backgroundColor: color,
  opacity: pressed ? 0.5 : 1,
  justifyContent: 'center',
  alignItems: 'center'
})

const rightColorContainer = (pressed: boolean, color: string): Readonly<ViewStyle> => ({
  width: '100%',
  height: '100%',
  backgroundColor: color,
  opacity: pressed ? 0.5 : 1,
  borderTopRightRadius: auxRadius,
  borderBottomRightRadius: auxRadius,
  justifyContent: 'center',
  alignItems: 'center'
})

const colorMark = (selected: boolean, color: string): Readonly<TextStyle> => ({
  color: selected ? contrastColor({ bgColor: color }) : 'transparent'
})

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
  selectedLabel,
  separator,
  colorMark
} as const
