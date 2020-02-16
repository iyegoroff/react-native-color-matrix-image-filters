import React from 'react'
import { requireNativeComponent } from 'react-native'
import { defaultStyle, checkStyle } from './style'

const ColorMatrixImageFilter = requireNativeComponent('CMIFColorMatrixImageFilter')

export const NativeFilter = React.forwardRef(
  ({ style, ...restProps }, ref) => {
    checkStyle(style)

    return (
      <ColorMatrixImageFilter
        style={[defaultStyle.container, style]}
        ref={ref}
        {...restProps}
      />
    )
  }
)
