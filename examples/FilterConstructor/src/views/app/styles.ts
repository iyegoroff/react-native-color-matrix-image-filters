import { Dimensions, ImageStyle, ViewStyle } from 'react-native'

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
}

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

export const styles = {
  container,
  image,
  filterControlList,
  pickerControls,
  fullscreenImage,
  modalOverlay,
  frame
} as const
