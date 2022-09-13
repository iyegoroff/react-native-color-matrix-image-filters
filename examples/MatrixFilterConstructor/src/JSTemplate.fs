namespace MatrixFilterConstructor

module JSTemplate =

  let template = """import * as React from 'react';
import { Image } from 'react-native';
import {
  ColorMatrix,
  concatColorMatrices,
  __IMPORTS__
} from 'react-native-color-matrix-image-filters';

export default const FilteredImage = (props) => {
  const {
    __PROPS__
    ...imageProps
  } = props;

  const matrix = concatColorMatrices([
    __MATRICES__
  ]);

  return (
    <ColorMatrix matrix={matrix}>
      <Image {...imageProps} />
    </ColorMatrix>
  );
};
"""