import React from 'react';
import { NativeFilter } from './native-filter';
import filters from 'rn-color-matrices';
import { concatTwoColorMatrices, concatColorMatrices } from 'concat-color-matrices';

const ColorMatrixFilter = ({ matrix, parentMatrix, children, ...restProps }) => {
  const mat = Array.isArray(matrix[0]) ? concatColorMatrices(matrix) : matrix;

  const concatedMatrix = parentMatrix ? concatTwoColorMatrices(mat, parentMatrix) : mat;
  const child = React.Children.only(children);

  return child && child.type && child.type.isColorMatrixFilter
    ? React.cloneElement(child, { ...child.props, parentMatrix: concatedMatrix })
    : (
      <NativeFilter
        matrix={concatedMatrix}
        {...restProps}
      >
        {children}
      </NativeFilter>
    );
};

ColorMatrixFilter.isColorMatrixFilter = true;
ColorMatrixFilter.displayName = 'ColorMatrix';

const filterName = ([first, ...rest]) => first.toUpperCase() + rest.join('');

const createColorMatrixImageFilter = (filter) => ({ value, ...restProps }) => (
  <ColorMatrixFilter
    matrix={filter(value)}
    {...restProps}
  />
);

const createColorToneImageFilter = (filter) => ({
  desaturation,
  toned,
  lightColor,
  darkColor,
  ...restProps
}) => (
  <ColorMatrixFilter
    matrix={filter(desaturation, toned, lightColor, darkColor)}
    {...restProps}
  />
);

const createRGBAImageFilter = (filter) => ({ red, green, blue, alpha, ...restProps }) => (
  <ColorMatrixFilter
    matrix={filter(red, green, blue, alpha)}
    {...restProps}
  />
);

export default Object.keys(filters).reduce(
  (acc, name) => {
    const key = filterName(name);
    const create = key === 'ColorTone'
      ? createColorToneImageFilter
      : key === 'RGBA' ? createRGBAImageFilter : createColorMatrixImageFilter;

    acc[key] = create(filters[name]);
    acc[key].displayName = key;
    acc[key].isColorMatrixFilter = true;
    return acc;
  },
  { 'ColorMatrix': ColorMatrixFilter }
);
