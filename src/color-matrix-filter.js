import React from 'react'
import { NativeFilter } from './native-filter'
import filters from 'rn-color-matrices'
import { concatTwoColorMatrices, concatColorMatrices } from 'concat-color-matrices'

const ColorMatrixFilter = React.forwardRef(
  ({ matrix, parentMatrix, children, ...restProps }, ref) => {
    const mat = Array.isArray(matrix[0]) ? concatColorMatrices(matrix) : matrix

    const concatedMatrix = parentMatrix ? concatTwoColorMatrices(mat, parentMatrix) : mat
    const child = React.Children.only(children)

    return child && child.type && child.type.isColorMatrixFilter
      ? React.cloneElement(child, { ...child.props, ref, parentMatrix: concatedMatrix })
      : (
        <NativeFilter
          matrix={concatedMatrix}
          ref={ref}
          {...restProps}
        >
          {children}
        </NativeFilter>
      )
  }
)

ColorMatrixFilter.isColorMatrixFilter = true
ColorMatrixFilter.displayName = 'ColorMatrix'

const filterName = (name) => {
  const [first, ...rest] = name.split('')
  return name === 'rgba' ? 'RGBA' : first.toUpperCase() + rest.join('')
}

const filterMap = {
  ColorTone: (filter) => React.forwardRef(
    ({ desaturation, toned, lightColor, darkColor, ...restProps }, ref) => (
      <ColorMatrixFilter
        matrix={filter(desaturation, toned, lightColor, darkColor)}
        ref={ref}
        {...restProps}
      />
    )
  ),

  RGBA: (filter) => React.forwardRef(
    ({ red, green, blue, alpha, ...restProps }, ref) => (
      <ColorMatrixFilter
        matrix={filter(red, green, blue, alpha)}
        ref={ref}
        {...restProps}
      />
    )
  ),

  DuoTone: (filter) => React.forwardRef(
    ({ firstColor, secondColor, ...restProps }, ref) => (
      <ColorMatrixFilter
        matrix={filter(firstColor, secondColor)}
        ref={ref}
        {...restProps}
      />
    )
  )
}

const createFilter = (key) => filterMap[key] || ((filter) => React.forwardRef(
  ({ amount, ...restProps }, ref) => (
    <ColorMatrixFilter
      matrix={filter(amount)}
      ref={ref}
      {...restProps}
    />
  )
))

export default Object.keys(filters).reduce(
  (acc, name) => {
    const key = filterName(name)

    acc[key] = createFilter(key)(filters[name])
    acc[key].displayName = key
    acc[key].isColorMatrixFilter = true
    return acc
  },
  { ColorMatrix: ColorMatrixFilter }
)
