
# react-native-color-matrix-image-filters
[![npm version](https://badge.fury.io/js/react-native-color-matrix-image-filters.svg?t=1495378566925)](https://badge.fury.io/js/react-native-color-matrix-image-filters)
[![js-semistandard-style](https://img.shields.io/badge/code%20style-semistandard-brightgreen.svg)](https://github.com/Flet/semistandard)
[![Dependency Status](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters.svg?t=1495378566925)](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters)
[![devDependencies Status](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters/dev-status.svg)](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters?type=dev)
[![typings included](https://img.shields.io/badge/typings-included-brightgreen.svg?t=1495378566925)](src/index.d.ts)
[![npm](https://img.shields.io/npm/l/express.svg?t=1495378566925)](https://www.npmjs.com/package/react-native-color-matrix-image-filters)

Various color matrix based image filters for iOS & Android.

## Getting started

`$ npm install react-native-color-matrix-image-filters --save`

### Mostly automatic installation

`$ react-native link react-native-color-matrix-image-filters`

#### Cocoapods

add the following line to your Podfile:

```sh
pod 'React', :path => '../node_modules/react-native'
pod 'RNColorMatrixImageFilters', :path => '../node_modules/react-native-color-matrix-image-filters'
```


### Manual installation

[link](manual_installation.md)

## Status

- iOS & Android - filter components work as stackable wrappers for standard `Image` and
  `ImageBackground` components.
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
    matrix={concatColorMatrices([saturate(-0.9), contrast(5.2), invert()])}
    // alt: matrix={[saturate(-0.9), contrast(5.2), invert()]}
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

Each filter support all of `View` [props](https://facebook.github.io/react-native/docs/view#props).
Also some filters have optional `value` prop which takes a `number`. `ColorMatrix` filter
has `matrix` prop which takes a `Matrix` - an array of 20 numbers. Additionally library exports
functions like `grayscale`, `tint` etc. - these functions return values of `Matrix` type and their
results can be combined with `concatColorMatrices` function. If you need to combine several filters,
consider using `ColorMatrix` with `concatColorMatrices` - generally it is more performant than
corresponding stack of filter components.

## Reference

### Supported filters

| Component         | Additional props    | function          |
| ----------------- | ------------------- | ----------------- |
| ColorMatrix       | matrix: Matrix \| Array\<Matrix>      | -
| Normal            | -                   | normal(): Matrix
| Saturate          | value: number = 1   | saturate(value: number = 1): Matrix
| HueRotate         | value: number = 0   | hueRotate(value: number = 0): Matrix
| LuminanceToAlpha  | -                   | luminanceToAlpha(): Matrix
| Invert            | -                   | invert(): Matrix
| Grayscale         | -                   | grayscale(): Matrix
| Sepia             | -                   | sepia(): Matrix
| Nightvision       | -                   | nightvision(): Matrix
| Warm              | -                   | warm(): Matrix
| Cool              | -                   | cool(): Matrix
| Brightness        | value: number = 0   | brightness(value: number = 0): Matrix
| Exposure          | value: number = 1   | exposure(value: number = 1): Matrix
| Contrast          | value: number = 1   | contrast(value: number = 1): Matrix
| Temperature       | value: number = 1   | temperature(value: number = 1): Matrix
| Tint              | value: number = 0   | tint(value: number = 0): Matrix
| Threshold         | value: number = 0   | threshold(value: number = 0): Matrix
| Technicolor       | -                   | technicolor(): Matrix
| Polaroid          | -                   | polaroid(): Matrix
| ToBGR             | -                   | toBGR(): Matrix
| Kodachrome        | -                   | kodachrome(): Matrix
| Browni            | -                   | browni(): Matrix
| Vintage           | -                   | vintage(): Matrix
| Night             | value: number = 0.1 | night(value: number = 0.1): Matrix
| Predator          | value: number = 1   | predator(value: number = 1): Matrix
| Lsd               | -                   | lsd(): Matrix
| ColorTone         | desaturation: number = 0.2, toned: number = 0.15, lightColor: string = "#FFE580", darkColor: string = "#338000" | colorTone(desaturation: number = 0.2, toned: number = 0.15, lightColor: string = "#FFE580", darkColor: string = "#338000"): Matrix
| Protanomaly       | -                   | protanomaly(): Matrix
| Deuteranomaly     | -                   | deuteranomaly(): Matrix
| Tritanomaly       | -                   | tritanomaly(): Matrix
| Protanopia        | -                   | protanopia(): Matrix
| Deuteranopia      | -                   | deuteranopia(): Matrix
| Tritanopia        | -                   | tritanopia(): Matrix
| Achromatopsia     | -                   | achromatopsia(): Matrix
| Achromatomaly     | -                   | achromatomaly(): Matrix


### Functions

- concatColorMatrices(matrices: Matrix[]): Matrix

### Matrix type

- A 4x5 matrix for color transformations represented by [array]() -
  consult [Android docs](https://developer.android.com/reference/android/graphics/ColorMatrix)
	for more specific info about it's format

## Misc

- You may check [MatrixFilterConstructor](MatrixFilterConstructor/) example app to play with filters
- This library was tested only with standard `Image` component, but in theory it should work with
  any image which native part is based on `RCTImageView` on iOS or `ImageView` on Android

## Credits

- parrot [image](https://commons.wikimedia.org/wiki/File:Ara_macao_-flying_away-8a.jpg) by
  [Robert01](https://de.wikipedia.org/wiki/Benutzer:Robert01)
- all color filters are taken from [color-matrix](https://github.com/skratchdot/color-matrix)
  project by @skratchdot and Pixi.js [sources](https://goo.gl/1GLTCU)
- `concatColorMatrices` function is based on Android SDK [sources](https://goo.gl/MMDopQ)
