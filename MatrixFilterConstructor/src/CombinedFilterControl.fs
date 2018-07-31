namespace MatrixFilterConstructor

open Fable.Import
open Fable.Helpers

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RNF = Fable.Import.ReactNativeColorMatrixImageFilters

module CombinedFilterControl =

  type Model =
    | Normal
    | Saturate
    | HueRotate
    | LuminanceToAlpha
    | Invert
    | Grayscale
    | Sepia
    | Nightvision
    | Warm
    | Cool
    | Brightness
    | Exposure
    | Contrast
    | Temperature
    | Tint
    | Threshold
    | Protanomaly
    | Deuteranomaly
    | Tritanomaly
    | Protanopia
    | Deuteranopia
    | Tritanopia
    | Achromatopsia
    | Achromatomaly


  let name =
    sprintf "%A"

  let init model : FilterControl.Model =
    match model with
    | Normal -> None
    | Saturate -> Some (FilterRangeInput.init -10. 10.)
    | HueRotate -> Some (FilterRangeInput.init -10. 10.)
    | LuminanceToAlpha -> None
    | Invert -> None
    | Grayscale -> None
    | Sepia -> None
    | Nightvision -> None
    | Warm -> None
    | Cool -> None
    | Brightness -> Some (FilterRangeInput.init -100. 100.)
    | Exposure -> Some (FilterRangeInput.init -10. 10.)
    | Contrast -> Some (FilterRangeInput.init -10. 10.)
    | Temperature -> Some (FilterRangeInput.init -10. 10.)
    | Tint -> Some (FilterRangeInput.init -10. 10.)
    | Threshold -> Some (FilterRangeInput.init -100. 100.)
    | Protanomaly -> None
    | Deuteranomaly -> None
    | Tritanomaly -> None
    | Protanopia -> None
    | Deuteranopia -> None
    | Tritanopia -> None
    | Achromatopsia -> None
    | Achromatomaly -> None

  let matrix control (model: FilterControl.Model) =
    let value =
      match model with
      | Some input -> input.Value
      | _ -> 0.
    
    match control with
    | Normal -> RNF.normal ()
    | Saturate -> RNF.saturate value
    | HueRotate -> RNF.hueRotate value
    | LuminanceToAlpha -> RNF.luminanceToAlpha ()
    | Invert -> RNF.invert ()
    | Grayscale -> RNF.grayscale ()
    | Sepia -> RNF.sepia ()
    | Nightvision -> RNF.nightvision ()
    | Warm -> RNF.warm ()
    | Cool -> RNF.cool ()
    | Brightness -> RNF.brightness value
    | Exposure -> RNF.exposure value
    | Contrast -> RNF.contrast value
    | Temperature -> RNF.temperature value
    | Tint -> RNF.tint value
    | Threshold -> RNF.threshold value
    | Protanomaly -> RNF.protanomaly ()
    | Deuteranomaly -> RNF.deuteranomaly ()
    | Tritanomaly -> RNF.tritanomaly ()
    | Protanopia -> RNF.protanopia ()
    | Deuteranopia -> RNF.deuteranopia ()
    | Tritanopia -> RNF.tritanopia ()
    | Achromatopsia -> RNF.achromatopsia ()
    | Achromatomaly -> RNF.achromatomaly ()

  let view =
    function
    | Normal -> FilterControl.view (name Normal)
    | Saturate -> FilterControl.view (name Saturate)
    | HueRotate -> FilterControl.view (name HueRotate)
    | LuminanceToAlpha -> FilterControl.view (name LuminanceToAlpha)
    | Invert -> FilterControl.view (name Invert)
    | Grayscale -> FilterControl.view (name Grayscale)
    | Sepia -> FilterControl.view (name Sepia)
    | Nightvision -> FilterControl.view (name Nightvision)
    | Warm -> FilterControl.view (name Warm)
    | Cool -> FilterControl.view (name Cool)
    | Brightness -> FilterControl.view (name Brightness)
    | Exposure -> FilterControl.view (name Exposure)
    | Contrast -> FilterControl.view (name Contrast)
    | Temperature -> FilterControl.view (name Temperature)
    | Tint -> FilterControl.view (name Tint)
    | Threshold -> FilterControl.view (name Threshold)
    | Protanomaly -> FilterControl.view (name Protanomaly)
    | Deuteranomaly -> FilterControl.view (name Deuteranomaly)
    | Tritanomaly -> FilterControl.view (name Tritanomaly)
    | Protanopia -> FilterControl.view (name Protanopia)
    | Deuteranopia -> FilterControl.view (name Deuteranopia)
    | Tritanopia -> FilterControl.view (name Tritanopia)
    | Achromatopsia -> FilterControl.view (name Achromatopsia)
    | Achromatomaly -> FilterControl.view (name Achromatomaly)

  let availableFilters: Model array =
    [| Normal
       Saturate
       HueRotate
       LuminanceToAlpha
       Invert
       Grayscale
       Sepia
       Nightvision
       Warm
       Cool
       Brightness
       Exposure
       Contrast
       Temperature
       Tint
       Threshold
       Protanomaly
       Deuteranomaly
       Tritanomaly
       Protanopia
       Deuteranopia
       Tritanopia
       Achromatopsia
       Achromatomaly |]
