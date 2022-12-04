import { TextStyle, ViewStyle } from 'react-native'

const close: ViewStyle = {
  position: 'absolute',
  right: 30,
  top: 30
}

const closeLabel: TextStyle = {
  fontSize: 48
}

const optionList: ViewStyle = {
  paddingHorizontal: 5
}

export const styles = {
  close,
  closeLabel,
  optionList
} as const
