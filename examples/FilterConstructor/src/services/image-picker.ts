import { launchCamera, launchImageLibrary } from 'react-native-image-picker'

const takePhoto = (launch: typeof launchCamera | typeof launchImageLibrary) => async () => {
  const { assets, didCancel, errorMessage } = await launch({ mediaType: 'photo' })
  const photo = assets?.[0]?.uri

  if (errorMessage !== undefined) {
    throw new Error(errorMessage)
  }

  return didCancel === true || photo === undefined ? 'canceled' : { uri: photo }
}

export const ImagePicker = {
  takePhotoFromCamera: takePhoto(launchCamera),
  pickPhotoFromLibrary: takePhoto(launchImageLibrary)
} as const

export type ImagePicker = typeof ImagePicker
