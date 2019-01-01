import React from 'react'
import { NativeFilter } from './native-filter'
import filters from 'rn-color-matrices'
import { concatTwoColorMatrices, concatColorMatrices } from 'concat-color-matrices'

const ColorMatrixFilter = ({ matrix, parentMatrix, children, ...restProps }) => {
  const mat = Array.isArray(matrix[0]) ? concatColorMatrices(matrix) : matrix

  const concatedMatrix = parentMatrix ? concatTwoColorMatrices(mat, parentMatrix) : mat
  const child = React.Children.only(children)

  return child && child.type && child.type.isColorMatrixFilter
    ? React.cloneElement(child, { ...child.props, parentMatrix: concatedMatrix })
    : (
      <NativeFilter
        matrix={concatedMatrix}
        {...restProps}
      >
        {children}
      </NativeFilter>
    )
}

ColorMatrixFilter.isColorMatrixFilter = true
ColorMatrixFilter.displayName = 'ColorMatrix'

const filterName = (name) => {
  const [first, ...rest] = name.split('')
  return name === 'rgba' ? 'RGBA' : first.toUpperCase() + rest.join('')
}

const filterMap = {
  ColorTone: (filter) => ({ desaturation, toned, lightColor, darkColor, ...restProps }) => (
    <ColorMatrixFilter
      matrix={filter(desaturation, toned, lightColor, darkColor)}
      {...restProps}
    />
  ),

  RGBA: (filter) => ({ red, green, blue, alpha, ...restProps }) => (
    <ColorMatrixFilter
      matrix={filter(red, green, blue, alpha)}
      {...restProps}
    />
  ),

  DuoTone: (filter) => ({ firstColor, secondColor, ...restProps }) => (
    <ColorMatrixFilter
      matrix={filter(firstColor, secondColor)}
      {...restProps}
    />
  )
}

const createFilter = (key) => filterMap[key] || ((filter) => ({ amount, ...restProps }) => (
  <ColorMatrixFilter
    matrix={filter(amount)}
    {...restProps}
  />
))

export default Object.keys(filters).reduce(
  (acc, name) => {
    const key = filterName(name)

    acc[key] = createFilter(key)(filters[name])
    acc[key].displayName = key
    acc[key].isColorMatrixFilter = true
    return acc
  },
  { 'ColorMatrix': ColorMatrixFilter }
)
