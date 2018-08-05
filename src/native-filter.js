import React from 'react';
import { requireNativeComponent } from 'react-native';
import { defaultStyle, checkStyle } from './style';

const RNColorMatrixImageFilter = requireNativeComponent('RNColorMatrixImageFilter');

export const NativeFilter = ({ style, ...restProps }) => {
  checkStyle(style);

  return (
    <RNColorMatrixImageFilter
      style={[defaultStyle.container, style]}
      {...restProps}
    />
  );
};
