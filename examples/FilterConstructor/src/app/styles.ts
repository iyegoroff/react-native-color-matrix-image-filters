import { Dimensions, ImageStyle, ViewStyle } from 'react-native'

const size = Dimensions.get('screen').width - 10

const container: ViewStyle = {
  flex: 1,
  alignItems: 'center'
}

const image: ImageStyle = {
  width: size,
  height: size
}

export const styles = {
  container,
  image
}
