# react-native-color-matrix-image-filters
[![npm version](https://badge.fury.io/js/react-native-color-matrix-image-filters.svg?t=1495378566925)](https://badge.fury.io/js/react-native-color-matrix-image-filters)
[![CircleCI](https://circleci.com/gh/iyegoroff/react-native-color-matrix-image-filters.svg?style=svg)](https://circleci.com/gh/iyegoroff/react-native-color-matrix-image-filters)
[![js-standard-style](https://img.shields.io/badge/code%20style-standard-brightgreen.svg)](https://github.com/standard/standard)
[![Dependency Status](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters.svg?t=1495378566925)](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters)
[![devDependencies Status](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters/dev-status.svg)](https://david-dm.org/iyegoroff/react-native-color-matrix-image-filters?type=dev)
[![typings included](https://img.shields.io/badge/typings-included-brightgreen.svg?t=1495378566925)](src/index.d.ts)
[![npm](https://img.shields.io/npm/l/express.svg?t=1495378566925)](https://www.npmjs.com/package/react-native-color-matrix-image-filters)

Various color matrix based image filters for iOS & Android.

## Status

- iOS & Android:
  - filter components work as stackable wrappers for `Image`, `ImageBackground` and [react-native-fast-image](https://github.com/DylanVann/react-native-fast-image) components
- react-native:
  - supported versions: "<strong>>=0.56.0</strong>"

## Installation

<table>
<td>
<details style="border: 1px solid; border-radius: 5px; padding: 5px; margin-bottom: 3px">
  <summary>with react-native "<strong>>=0.60.0</strong>"</summary>

### 1. Install latest version from npm

`$ npm i react-native-color-matrix-image-filters -S`

### 2. Install pods

`$ cd ios && pod install && cd ..`

</details>
</td>
</table>
<table>
<td>
<details style="border: 1px solid; border-radius: 5px; padding: 5px">
  <summary>with react-native "<strong>>=0.56.0 <0.60.0</strong>"</summary>

### 1. Install latest version from npm

`$ npm i react-native-color-matrix-image-filters -S`

### 2-a. Link native modules

`$ react-native link react-native-color-matrix-image-filters`

### 2-b. Install pods

If you use Cocoapods add the following line to your Podfile:

```sh
pod 'React', :path => '../node_modules/react-native'
pod 'RNColorMatrixImageFilters', :path => '../node_modules/react-native-color-matrix-image-filters'
```

`$ cd ios && pod install && cd ..`

### 2-c. Manual installation

Install manually if `react-native link` failed - [link](manual_installation.md)

</details>
</td>
</table>

## Scope

This module is meant to be used for simple stuff, like "grayscaling inactive user avatar" etc. Check
[react-native-image-filter-kit](https://github.com/iyegoroff/react-native-image-filter-kit) if
you need some advanced features like image blending/composing, extracting filtering results to file system
and ability to create custom filters.

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
  <Tint amount={1.25}>
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
<img src="https://github.com/iyegoroff/react-native-color-matrix-image-filters/raw/master/img/parrot.png" align="left" height="200">  |  <img src="https://github.com/iyegoroff/react-native-color-matrix-image-filters/raw/master/img/gray.png" align="right" height="200">

CombinedFilters                                |  ColorMatrix
:---------------------------------------------:|:---------------------------------------------:
<img src="https://github.com/iyegoroff/react-native-color-matrix-image-filters/raw/master/img/combined.png" align="left" height="200">  |  <img src="https://github.com/iyegoroff/react-native-color-matrix-image-filters/raw/master/img/color-matrix.png" align="right" height="200">

## Usage

Each filter support all of `View` [props](https://facebook.github.io/react-native/docs/view#props).
Also some filters have optional `amount` prop which takes a `number`. `ColorMatrix` filter
has `matrix` prop which takes a `Matrix` - an array of 20 numbers. Additionally library exports
functions like `grayscale`, `tint` etc. - these functions return values of `Matrix` type and their
results can be combined with `concatColorMatrices` function. If you need to combine several filters,
consider using `ColorMatrix` with `concatColorMatrices` - generally it is more performant than
corresponding stack of filter components.

## Reference

### Supported filters

| Component         | Additional props     | function          |
| ----------------- | -------------------- | ----------------- |
| ColorMatrix       | matrix: Matrix \| Array\<Matrix>      | -
| Normal            | -                    | normal(): Matrix
| RGBA              | red: number = 1, green: number = 1, blue: number = 1, alpha: number = 1 | rgba(red: number = 1, green: number = 1, blue: number = 1, alpha: number = 1): Matrix
| Saturate          | amount: number = 1   | saturate(amount: number = 1): Matrix
| HueRotate         | amount: number = 0   | hueRotate(amount: number = 0): Matrix
| LuminanceToAlpha  | -                    | luminanceToAlpha(): Matrix
| Invert            | -                    | invert(): Matrix
| Grayscale         | amount: number = 1   | grayscale(amount: number = 1): Matrix
| Sepia             | amount: number = 1   | sepia(amount: number = 1): Matrix
| Nightvision       | -                    | nightvision(): Matrix
| Warm              | -                    | warm(): Matrix
| Cool              | -                    | cool(): Matrix
| Brightness        | amount: number = 1   | brightness(amount: number = 1): Matrix
| Contrast          | amount: number = 1   | contrast(amount: number = 1): Matrix
| Temperature       | amount: number = 1   | temperature(amount: number = 1): Matrix
| Tint              | amount: number = 0   | tint(amount: number = 0): Matrix
| Threshold         | amount: number = 0   | threshold(amount: number = 0): Matrix
| Technicolor       | -                    | technicolor(): Matrix
| Polaroid          | -                    | polaroid(): Matrix
| ToBGR             | -                    | toBGR(): Matrix
| Kodachrome        | -                    | kodachrome(): Matrix
| Browni            | -                    | browni(): Matrix
| Vintage           | -                    | vintage(): Matrix
| Night             | amount: number = 0.1 | night(amount: number = 0.1): Matrix
| Predator          | amount: number = 1   | predator(amount: number = 1): Matrix
| Lsd               | -                    | lsd(): Matrix
| ColorTone         | desaturation: number = 0.2, toned: number = 0.15, lightColor: string = "#FFE580", darkColor: string = "#338000" | colorTone(desaturation: number = 0.2, toned: number = 0.15, lightColor: string = "#FFE580", darkColor: string = "#338000"): Matrix
| DuoTone           | firstColor: string = "#FFE580", secondColor: string = "#338000" | duoTone(firstColor: string = "#FFE580", secondColor: string = "#338000"): Matrix
| Protanomaly       | -                    | protanomaly(): Matrix
| Deuteranomaly     | -                    | deuteranomaly(): Matrix
| Tritanomaly       | -                    | tritanomaly(): Matrix
| Protanopia        | -                    | protanopia(): Matrix
| Deuteranopia      | -                    | deuteranopia(): Matrix
| Tritanopia        | -                    | tritanopia(): Matrix
| Achromatopsia     | -                    | achromatopsia(): Matrix
| Achromatomaly     | -                    | achromatomaly(): Matrix


### Functions

- concatColorMatrices(matrices: Matrix[]): Matrix

### Matrix type

- A 4x5 matrix for color transformations represented by array -
  consult [Android docs](https://developer.android.com/reference/android/graphics/ColorMatrix)
	for more specific info about it's format

## Misc

- You may check [MatrixFilterConstructor](MatrixFilterConstructor/) example app to play with filters
- This library was tested only with standard `Image` component, but in theory it should work with
  any image that conforms to [CMIFResizable](https://github.com/iyegoroff/react-native-color-matrix-image-filters/blob/master/ios/CMIFResizable.h) protocol or is based on Android `ImageView` class
- Installing `react-native-fast-image` is <strong>not required</strong> - this module doesn't depend on it

## Credits

- parrot [image](https://commons.wikimedia.org/wiki/File:Ara_macao_-flying_away-8a.jpg) by
  [Robert01](https://de.wikipedia.org/wiki/Benutzer:Robert01)
- most of color filters are taken from [color-matrix](https://github.com/skratchdot/color-matrix)
  project by @skratchdot, Pixi.js [sources](https://github.com/pixijs/pixi.js/blob/dev/src/filters/colormatrix/ColorMatrixFilter.js)
  and Webkit [sources](https://github.com/WebKit/webkit/blob/fd2225c344d4ea5ebcf1bdf437df251d95f8035c/Source/WebCore/platform/graphics/ColorUtilities.cpp)
- `concatColorMatrices` function is based on Android SDK [sources](https://github.com/AndroidSDKSources/android-sdk-sources-for-api-level-27/blob/048d6cef38d11a9937bccc8cec517c1b149904c5/android/graphics/ColorMatrix.java#L181-L205)
- `DuoTone` filter based on [example](https://codepen.io/jmperez/pen/LGqaxQ) by José Manuel Pérez
