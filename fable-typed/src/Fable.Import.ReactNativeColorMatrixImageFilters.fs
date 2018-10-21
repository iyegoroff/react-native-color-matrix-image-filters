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

  type RGBAProps =
    | Style of IStyle list
    | Red of float
    | Green of float
    | Blue of float
    | Alpha of float

  type SaturateProps =
    | Style of IStyle list
    | Amount of float

  type HueRotateProps =
    | Style of IStyle list
    | Amount of float

  type LuminanceToAlphaProps =
    | Style of IStyle list

  type InvertProps =
    | Style of IStyle list

  type GrayscaleProps =
    | Style of IStyle list
    | Amount of float

  type SepiaProps =
    | Style of IStyle list
    | Amount of float

  type NightvisionProps =
    | Style of IStyle list

  type WarmProps =
    | Style of IStyle list

  type CoolProps =
    | Style of IStyle list

  type BrightnessProps =
    | Style of IStyle list
    | Amount of float

  type ContrastProps =
    | Style of IStyle list
    | Amount of float

  type TemperatureProps =
    | Style of IStyle list
    | Amount of float

  type TintProps =
    | Style of IStyle list
    | Amount of float

  type ThresholdProps =
    | Style of IStyle list
    | Amount of float

  type TechnicolorProps =
    | Style of IStyle list

  type PolaroidProps =
    | Style of IStyle list

  type ToBGRProps =
    | Style of IStyle list

  type KodachromeProps =
    | Style of IStyle list

  type BrowniProps =
    | Style of IStyle list

  type VintageProps =
    | Style of IStyle list

  type NightProps =
    | Style of IStyle list
    | Amount of float

  type PredatorProps =
    | Style of IStyle list
    | Amount of float

  type LsdProps =
    | Style of IStyle list

  type ColorToneProps =
    | Desaturation of float
    | Toned of float
    | LightColor of string
    | DarkColor of string
    | Style of IStyle list

  type DuoToneProps =
    | Style of IStyle list
    | FirstColor of string
    | SecondColor of string

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

let concatColorMatrices (_matrices: Matrix array): Matrix =
  importMember "react-native-color-matrix-image-filters"
let normal (): Matrix = importMember "react-native-color-matrix-image-filters"
let rgba (_red: float) (_green: float) (_blue: float) (_alpha: float): Matrix =
  importMember "react-native-color-matrix-image-filters"
let saturate (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let hueRotate (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let luminanceToAlpha (): Matrix = importMember "react-native-color-matrix-image-filters"
let invert (): Matrix = importMember "react-native-color-matrix-image-filters"
let grayscale (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let sepia (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let nightvision (): Matrix = importMember "react-native-color-matrix-image-filters"
let warm (): Matrix = importMember "react-native-color-matrix-image-filters"
let cool (): Matrix = importMember "react-native-color-matrix-image-filters"
let brightness (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let contrast (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let temperature (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let tint (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let threshold (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let technicolor (): Matrix = importMember "react-native-color-matrix-image-filters"
let polaroid (): Matrix = importMember "react-native-color-matrix-image-filters"
let toBGR (): Matrix = importMember "react-native-color-matrix-image-filters"
let kodachrome (): Matrix = importMember "react-native-color-matrix-image-filters"
let browni (): Matrix = importMember "react-native-color-matrix-image-filters"
let vintage (): Matrix = importMember "react-native-color-matrix-image-filters"
let night (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let predator (_v: float): Matrix = importMember "react-native-color-matrix-image-filters"
let lsd (): Matrix = importMember "react-native-color-matrix-image-filters"
let colorTone (_desaturation: float) (_toned: float) (_lightColor: string) (_darkColor: string): Matrix =
  importMember "react-native-color-matrix-image-filters"
let duoTone (_firstColor: string) (_secondColor: string): Matrix =
  importMember "react-native-color-matrix-image-filters"
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

let inline RGBA (props: RGBAProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "RGBA" "react-native-color-matrix-image-filters" (propsToObj props) children

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

let inline Contrast (props: ContrastProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Contrast" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Temperature (props: TemperatureProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Temperature" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Tint (props: TintProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Tint" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Threshold (props: ThresholdProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Threshold" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Technicolor (props: TechnicolorProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Technicolor" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Polaroid (props: PolaroidProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Polaroid" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline ToBGR (props: ToBGRProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "ToBGR" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Kodachrome (props: KodachromeProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Kodachrome" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Browni (props: BrowniProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Browni" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Vintage (props: VintageProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Vintage" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Night (props: NightProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Night" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Predator (props: PredatorProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Predator" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline Lsd (props: LsdProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "Lsd" "react-native-color-matrix-image-filters" (propsToObj props) children

let inline ColorTone (props: ColorToneProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "ColorTone" "react-native-color-matrix-image-filters" (propsToObj props) children
let inline DuoTone (props: DuoToneProps list) (children: React.ReactElement list): React.ReactElement =
  ofImport "DuoTone" "react-native-color-matrix-image-filters" (propsToObj props) children

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
