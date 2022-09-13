import React from 'react'
import { requireNativeComponent, View, ViewProps } from 'react-native'
import { defaultStyle, checkStyle } from './style'

type Matrix = readonly [
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number,
  number
]

const NativeColorMatrixImageFilter = requireNativeComponent<ViewProps>('CMIFColorMatrixImageFilter')

export const ColorMatrixImageFilter = React.forwardRef(function ColorMatrixImageFilter(
  { style, ...restProps }: ViewProps & { readonly matrix: Matrix },
  ref: React.Ref<View>
) {
  checkStyle(style)

  return (
    <NativeColorMatrixImageFilter
      style={[defaultStyle.container, style]}
      {...restProps}
      ref={ref}
    />
  )
})
