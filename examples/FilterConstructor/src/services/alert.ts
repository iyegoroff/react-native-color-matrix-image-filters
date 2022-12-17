import { Alert as NativeAlert } from 'react-native'

const showAlert = (title: string, message: string) => {
  NativeAlert.alert(title, message)
}

export const Alert = {
  showAlert
} as const

export type Alert = typeof Alert
