import { Dimensions, TextStyle, ViewStyle } from 'react-native'
import { theme } from '../theme'

const { borderRadius, primaryColor } = theme

const width = Dimensions.get('screen').width - 10

const container: ViewStyle = {
  borderWidth: 1,
  borderRadius,
  borderColor: primaryColor,
  padding: 5,
  width
}

const label: TextStyle = {
  color: primaryColor,
  fontWeight: 'bold'
}

const name: TextStyle = {
  ...label,
  marginBottom: -5
}

const bottom: ViewStyle = {
  flexDirection: 'row',
  justifyContent: 'space-between',
  marginTop: -5
}

export const styles = {
  container,
  label,
  bottom,
  name
}
