import React from 'react';
import invariant from 'fbjs/lib/invariant';
import { NativeFilter } from './native-filter';
import filters from './matrix-filters';
import { concatTwoColorMatrices, concatColorMatrices } from './concat-color-matrices';

const ColorMatrixFilter = ({ matrix, parentMatrix, children, ...restProps }) => {
  const mat = Array.isArray(matrix[0]) ? concatColorMatrices(matrix) : matrix;
  
  invariant(mat.length === 20, `Color matrix should have 20 elements.`);

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

const createColorMatrixImageFilter = (filter) => ({ value, children, ...restProps }) => (
  <ColorMatrixFilter
    matrix={filter(value)}
    {...restProps}
  >
    {children}
  </ColorMatrixFilter>
);

export default Object.keys(filters).reduce(
  (acc, name) => {
    const key = filterName(name);
    acc[key] = createColorMatrixImageFilter(filters[name]);
    acc[key].displayName = key;
    acc[key].isColorMatrixFilter = true;
    return acc;
  },
  { 'ColorMatrix': ColorMatrixFilter }
);
