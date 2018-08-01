
# react-native-color-matrix-image-filters
[![npm version](https://badge.fury.io/js/react-native-color-matrix-image-filters.svg?t=1495378566925)](https://badge.fury.io/js/react-native-color-matrix-image-filters)
[![Dependency Status](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters.svg?t=1495378566925)](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters)
[![typings included](https://img.shields.io/badge/typings-included-brightgreen.svg?t=1495378566925)](src/index.d.ts)
[![npm](https://img.shields.io/npm/l/express.svg?t=1495378566925)](https://www.npmjs.com/package/react-native-color-matrix-image-filters)

Various color matrix based image filters for iOS & Android.

## Getting started

`$ npm install react-native-color-matrix-image-filters --save`

### Mostly automatic installation

`$ react-native link react-native-color-matrix-image-filters`

### Manual installation

[link](manual_installation.md)

## Status

- iOS & Android - filter components work as stackable wrappers for standard `Image` component.
- React-Native:
  - with rn >= 0.56.0 use latest version

## Example

```javascript
import { Image } from 'react-native';
import {
  Grayscale,
  Sepia,
  Tint,
  ColorMatrix,
  concatColorMatrices,
  invert,
  contrast,
  saturate
} from 'react-native-color-matrix-image-filters';

const GrayscaledImage = (imageProps) => (
  <Grayscale>
    <Image {...imageProps} />
  </Grayscale>
);

const CombinedFiltersImage = (imageProps) => (
  <Tint value={1.25}>
    <Sepia>
      <Image {...imageProps} />
    </Sepia>
  </Tint>
);

const ColorMatrixImage = (imageProps) => (
  <ColorMatrix
    matrix={concatColorMatrices([saturate(), contrast(5.16), invert(-0.94)])}
  >
    <Image {...imageProps} />
  </ColorMatrix>
);
```

Original                                       |  Grayscaled
:---------------------------------------------:|:---------------------------------------------:
<img src="img/parrot.png" align="left" height="200">  |  <img src="img/gray.png" align="right" height="200">

CombinedFilters                                |  ColorMatrix
:---------------------------------------------:|:---------------------------------------------:
<img src="img/combined.png" align="left" height="200">  |  <img src="img/color-matrix.png" align="right" height="200">

## Usage

All filters support `View` [props](https://facebook.github.io/react-native/docs/view#props).
Also some filters have optional `value` prop which takes a `number`. `ColorMatrix` filter
has `matrix` prop which takes a `Matrix` type - an array of 20 numbers. Additionally library exports
functions like `grayscale`, `tint` etc. - these functions return values of `Matrix` type and their
results can be combined with `concatColorMatrices` function. If you need to combine several filters,
consider using `ColorMatrix` with `concatColorMatrices` - generally it is more performant than
corresponding stack of filter components.

## Reference

### Supported filters

- ColorMatrix: [component]()
- Normal: [component](), [function]()
- Saturate: [component](), [function]()
- HueRotate: [component](), [function]()
- LuminanceToAlpha: [component](), [function]()
- Invert: [component](), [function]()
- Grayscale: [component](), [function]()
- Sepia: [component](), [function]()
- Nightvision: [component](), [function]()
- Warm: [component](), [function]()
- Cool: [component](), [function]()
- Brightness: [component](), [function]()
- Exposure: [component](), [function]()
- Contrast: [component](), [function]()
- Temperature: [component](), [function]()
- Tint: [component](), [function]()
- Threshold: [component](), [function]()
- Protanomaly: [component](), [function]()
- Deuteranomaly: [component](), [function]()
- Tritanomaly: [component](), [function]()
- Protanopia: [component](), [function]()
- Deuteranopia: [component](), [function]()
- Tritanopia: [component](), [function]()
- Achromatopsia: [component](), [function]()
- Achromatomaly: [component](), [function]()

### Functions

- `concatColorMatrices(matrices: Matrix[]): Matrix`

### Matrix type

- A 4x5 matrix for color transformations represented by [array]() -
  consult [Android docs](https://developer.android.com/reference/android/graphics/ColorMatrix)
	for more specific info about it's format

## Playground

You may check [MatrixFilterConstructor](MatrixFilterConstructor/README.md) example app to play with
filters.

## Credits

- parrot [image](https://commons.wikimedia.org/wiki/File:Ara_macao_-flying_away-8a.jpg) by
  [Robert01](https://de.wikipedia.org/wiki/Benutzer:Robert01)
- all color filters are taken from [color-matrix](https://github.com/skratchdot/color-matrix)
  project by @skratchdot
- `concatColorMatrices` function is based on Android SDK [sources](https://github.com/AndroidSDKSources/android-sdk-sources-for-api-level-27/blob/048d6cef38d11a9937bccc8cec517c1b149904c5/android/graphics/ColorMatrix.java#L181-L205)
  