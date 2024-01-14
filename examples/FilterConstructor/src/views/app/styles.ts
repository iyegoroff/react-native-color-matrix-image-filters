import { Dimensions, ImageStyle, TextStyle, ViewStyle } from 'react-native'

const size = Dimensions.get('screen').width

const frame: ViewStyle = {
  margin: 5
}

const container: ViewStyle = {
  flex: 1,
  alignItems: 'center',
  ...frame
}

const image: ImageStyle = {
  height: size / 2,
  width: '100%'
}

const fullscreenImage = {
  height: '100%',
  width: '100%'
} as const

const filterControlList: ViewStyle = {
  width: '100%'
}

const pickerControls: ViewStyle = {
  flexDirection: 'row',
  width: '100%'
}

const modalOverlay: ViewStyle = {
  backgroundColor: '#FFFFFFCC'
}

const info: TextStyle = {
  position: 'absolute'
}

const imageContainer: ViewStyle = {
  width: '100%'
}

export const styles = {
  container,
  image,
  filterControlList,
  pickerControls,
  fullscreenImage,
  modalOverlay,
  frame,
  info,
  imageContainer
} as const
