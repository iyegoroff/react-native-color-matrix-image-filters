import { ViewProps } from 'react-native'
import codegenNativeComponent from 'react-native/Libraries/Utilities/codegenNativeComponent'

// eslint-disable-next-line @typescript-eslint/consistent-type-definitions
export interface NativeProps extends ViewProps {
  readonly matrix: readonly number[]
}

export default codegenNativeComponent<NativeProps>('CMIFColorMatrixImageFilter')
