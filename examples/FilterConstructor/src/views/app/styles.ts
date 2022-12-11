import { Dimensions, ImageStyle, ViewStyle } from 'react-native'

const size = Dimensions.get('screen').width

const container: ViewStyle = {
  flex: 1,
  alignItems: 'center',
  margin: 5
}

const image: ImageStyle = {
  height: size / 2,
  width: '100%'
}

const fullscreenImage: ImageStyle = {
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

export const styles = {
  container,
  image,
  filterControlList,
  pickerControls,
  fullscreenImage
} as const
