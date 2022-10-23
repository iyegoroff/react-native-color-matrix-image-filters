import React from 'react'
import { View, ViewProps } from 'react-native'
import NativeColorMatrixImageFilter from './CMIFColorMatrixImageFilterNativeComponent'
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
