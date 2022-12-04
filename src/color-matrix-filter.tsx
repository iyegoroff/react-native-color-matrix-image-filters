import React from 'react'
import { Matrix } from 'concat-color-matrices'
import { View, ViewProps } from 'react-native'
import NativeColorMatrixImageFilter from './CMIFColorMatrixImageFilterNativeComponent'
import { defaultStyle, checkStyle } from './style'

export const ColorMatrixImageFilter = React.forwardRef(function ColorMatrixImageFilter(
  {
    style,
    ...restProps
  }: ViewProps & {
    readonly matrix: Matrix
  },
  ref: React.Ref<View>
) {
  checkStyle(style)

  return (
    <NativeColorMatrixImageFilter
      style={[defaultStyle.container, style]}
      {...restProps}
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      // @ts-expect-error
      ref={ref}
    />
  )
})
