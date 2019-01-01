import React from 'react'
import { requireNativeComponent } from 'react-native'
import { defaultStyle, checkStyle } from './style'

const ColorMatrixImageFilter = requireNativeComponent('CMIFColorMatrixImageFilter')

export const NativeFilter = ({ style, ...restProps }) => {
  checkStyle(style)

  return (
    <ColorMatrixImageFilter
      style={[defaultStyle.container, style]}
      {...restProps}
    />
  )
}
