module Fable.Import.ReactNativeColorMatrixImageFilters

open Fable.Helpers.ReactNative
open Fable.Helpers.React
open Fable.Helpers.ReactNative.Props
open Fable.Core.JsInterop
open Fable.Import


module Props =

  type Matrix =
    float * float * float * float * float * float * float * float * float * float *
    float * float * float * float * float * float * float * float * float * float

  type ColorMatrixProps =
    | Style of IStyle list
    | Matrix of Matrix

  type NormalProps =
    | Style of IStyle list

  type SaturateProps =
    | Style of IStyle list
    | Value of float

  type HueRotateProps =
    | Style of IStyle list
    | Value of float

  type LuminanceToAlphaProps =
    | Style of IStyle list

  type InvertProps =
    | Style of IStyle list

  type GrayscaleProps =
    | Style of IStyle list

  type SepiaProps =
    | Style of IStyle list

  type NightvisionProps =
    | Style of IStyle list

  type WarmProps =
    | Style of IStyle list

  type CoolProps =
    | Style of IStyle list

  type BrightnessProps =
    | Style of IStyle list
    | Value of float

  type ExposureProps =
    | Style of IStyle list
    | Value of float

  type ContrastProps =
    | Style of IStyle list
    | Value of float

  type TemperatureProps =
    | Style of IStyle list
    | Value of float

  type TintProps =
    | Style of IStyle list
    | Value of float

  type ThresholdProps =
    | Style of IStyle list
    | Value of float

  type ProtanomalyProps =
    | Style of IStyle list

  type DeuteranomalyProps =
    | Style of IStyle list

  type TritanomalyProps =
    | Style of IStyle list

  type ProtanopiaProps =
    | Style of IStyle list

  type DeuteranopiaProps =
    | Style of IStyle list

  type TritanopiaProps =
    | Style of IStyle list

  type AchromatopsiaProps =
    | Style of IStyle list

  type AchromatomalyProps =
    | Style of IStyle list


open Props
open Fable.Core

let concatColorMatrices (matrices: Matrix array): Matrix =
  importMember "react-native-color-matrix-image-filters"
let normal (): Matrix = importMember "react-native-color-matrix-image-filters"
let saturate (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let hueRotate (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let luminanceToAlpha (): Matrix = importMember "react-native-color-matrix-image-filters"
let invert (): Matrix = importMember "react-native-color-matrix-image-filters"
let grayscale (): Matrix = importMember "react-native-color-matrix-image-filters"
let sepia (): Matrix = importMember "react-native-color-matrix-image-filters"
let nightvision (): Matrix = importMember "react-native-color-matrix-image-filters"
let warm (): Matrix = importMember "react-native-color-matrix-image-filters"
let cool (): Matrix = importMember "react-native-color-matrix-image-filters"
let brightness (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let exposure (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let contrast (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let temperature (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let tint (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let threshold (v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let protanomaly (): Matrix = importMember "react-native-color-matrix-image-filters"
let deuteranomaly (): Matrix = importMember "react-native-color-matrix-image-filters"
let tritanomaly (): Matrix = importMember "react-native-color-matrix-image-filters"
let protanopia (): Matrix = importMember "react-native-color-matrix-image-filters"
let deuteranopia (): Matrix = importMember "react-native-color-matrix-image-filters"
let tritanopia (): Matrix = importMember "react-native-color-matrix-image-filters"
let achromatopsia (): Matrix = importMember "react-native-color-matrix-image-filters"
let achromatomaly (): Matrix = importMember "react-native-color-matrix-image-filters"

let inline private propsToObj (props: 'a list): obj = keyValueList CaseRules.LowerFirst props

let inline ColorMatrix (props: ColorMatrixProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "ColorMatrix" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Normal (props: NormalProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Normal" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Saturate (props: SaturateProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Saturate" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline HueRotate (props: HueRotateProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "HueRotate" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline LuminanceToAlpha (props: LuminanceToAlphaProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "LuminanceToAlpha" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Invert (props: InvertProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Invert" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Grayscale (props: GrayscaleProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Grayscale" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Sepia (props: SepiaProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Sepia" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Nightvision (props: NightvisionProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Nightvision" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Warm (props: WarmProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Warm" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Cool (props: CoolProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Cool" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Brightness (props: BrightnessProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Brightness" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Exposure (props: ExposureProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Exposure" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Contrast (props: ContrastProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Contrast" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Temperature (props: TemperatureProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Temperature" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Tint (props: TintProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Tint" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Threshold (props: ThresholdProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Threshold" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Protanomaly (props: ProtanomalyProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Protanomaly" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Deuteranomaly (props: DeuteranomalyProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Deuteranomaly" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Tritanomaly (props: TritanomalyProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Tritanomaly" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Protanopia (props: ProtanopiaProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Protanopia" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Deuteranopia (props: DeuteranopiaProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Deuteranopia" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Tritanopia (props: TritanopiaProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Tritanopia" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Achromatopsia (props: AchromatopsiaProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Achromatopsia" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Achromatomaly (props: AchromatomalyProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Achromatomaly" "react-native-color-matrix-image-filters" (propsToObj props) children
