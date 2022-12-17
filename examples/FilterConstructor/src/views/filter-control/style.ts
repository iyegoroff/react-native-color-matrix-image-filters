import { TextStyle, ViewStyle } from 'react-native'
import { theme } from '../theme'

const { borderRadius, primaryColor } = theme

const container: ViewStyle = {
  borderColor: primaryColor,
  borderWidth: 1,
  borderRadius,
  width: '100%',
  padding: 3,
  backgroundColor: 'aliceblue'
}

const label: TextStyle = {
  fontWeight: 'bold',
  color: primaryColor,
  flex: 4
}

const header: ViewStyle = {
  flexDirection: 'row'
}

export const styles = {
  container,
  label,
  header
} as const
