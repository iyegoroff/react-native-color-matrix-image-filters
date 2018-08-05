namespace MatrixFilterConstructor

open Fable.Helpers.ReactNative
open Fable.Import
open Fable.Helpers
open System
open Fable.Import.ReactNativeColorMatrixImageFilters.Props

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RNF = Fable.Import.ReactNativeColorMatrixImageFilters
module CFI = CombinedFilterInput

module CombinedFilter =

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
    | Technicolor
    | Polaroid
    | ToBGR
    | Kodachrome
    | Browni
    | Vintage
    | Night
    | Predator
    | Lsd
    | ColorTone
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

  let init model : Filter.Model =
    match model with
    | Normal -> Filter.init []

    | Saturate ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | HueRotate ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | LuminanceToAlpha -> Filter.init []

    | Invert -> Filter.init []

    | Grayscale -> Filter.init []

    | Sepia -> Filter.init []

    | Nightvision -> Filter.init []

    | Warm -> Filter.init []

    | Cool -> Filter.init []

    | Brightness ->
      Filter.init
        [ Filter.Value, CFI.initRange -100. 100. ]

    | Exposure ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | Contrast ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | Temperature ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | Tint ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | Threshold ->
      Filter.init
        [ Filter.Value, CFI.initRange -100. 100. ]

    | Technicolor -> Filter.init []

    | Polaroid -> Filter.init []

    | ToBGR -> Filter.init []

    | Kodachrome -> Filter.init []

    | Browni -> Filter.init []

    | Vintage -> Filter.init []

    | Night ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | Predator ->
      Filter.init
        [ Filter.Value, CFI.initRange -10. 10. ]

    | Lsd -> Filter.init []

    | ColorTone ->
      Filter.init
        [ Filter.Desaturation, CFI.initRange -10. 10.
          Filter.Toned, CFI.initRange -10. 10.
          Filter.LightColor, CFI.initColor
          Filter.DarkColor, CFI.initColor ]

    | Protanomaly -> Filter.init []

    | Deuteranomaly -> Filter.init []

    | Tritanomaly -> Filter.init []

    | Protanopia -> Filter.init []

    | Deuteranopia -> Filter.init []

    | Tritanopia -> Filter.init []

    | Achromatopsia -> Filter.init []

    | Achromatomaly -> Filter.init []


  let matrix control (model: Filter.Model) =
    match control, model with
    | Normal, _ -> RNF.normal ()
    | Saturate, [ Filter.Value, CFI.Range input ] -> RNF.saturate input.Value
    | HueRotate, [ Filter.Value, CFI.Range input ] -> RNF.hueRotate input.Value
    | LuminanceToAlpha, _ -> RNF.luminanceToAlpha ()
    | Invert, _ -> RNF.invert ()
    | Grayscale, _ -> RNF.grayscale ()
    | Sepia, _ -> RNF.sepia ()
    | Nightvision, _ -> RNF.nightvision ()
    | Warm, _ -> RNF.warm ()
    | Cool, _ -> RNF.cool ()
    | Brightness, [ Filter.Value, CFI.Range input ] -> RNF.brightness input.Value
    | Exposure, [ Filter.Value, CFI.Range input ] -> RNF.exposure input.Value
    | Contrast, [ Filter.Value, CFI.Range input ] -> RNF.contrast input.Value
    | Temperature, [ Filter.Value, CFI.Range input ] -> RNF.temperature input.Value
    | Tint, [ Filter.Value, CFI.Range input ] -> RNF.tint input.Value
    | Threshold, [ Filter.Value, CFI.Range input ] -> RNF.threshold input.Value
    | Technicolor, _ -> RNF.technicolor ()
    | Polaroid, _ -> RNF.polaroid ()
    | ToBGR, _ -> RNF.toBGR ()
    | Kodachrome, _ -> RNF.kodachrome ()
    | Browni, _ -> RNF.browni ()
    | Vintage, _ -> RNF.vintage ()
    | Night, [ Filter.Value, CFI.Range input ] -> RNF.night input.Value
    | Predator, [ Filter.Value, CFI.Range input ] -> RNF.predator input.Value
    | Lsd, _ -> RNF.lsd ()
    | ColorTone, 
      [ Filter.Desaturation, CFI.Range desaturation
        Filter.Toned, CFI.Range toned
        Filter.LightColor, CFI.Color lightColor
        Filter.DarkColor, CFI.Color darkColor ] ->
        RNF.colorTone desaturation.Value toned.Value lightColor.Value darkColor.Value
    | Protanomaly, _ -> RNF.protanomaly ()
    | Deuteranomaly, _ -> RNF.deuteranomaly ()
    | Tritanomaly, _ -> RNF.tritanomaly ()
    | Protanopia, _ -> RNF.protanopia ()
    | Deuteranopia, _ -> RNF.deuteranopia ()
    | Tritanopia, _ -> RNF.tritanopia ()
    | Achromatopsia, _ -> RNF.achromatopsia ()
    | Achromatomaly, _ -> RNF.achromatomaly ()
    | _ -> RNF.normal ()


  let controls =
    function
    | Normal -> Filter.controls (name Normal)
    | Saturate -> Filter.controls (name Saturate)
    | HueRotate -> Filter.controls (name HueRotate)
    | LuminanceToAlpha -> Filter.controls (name LuminanceToAlpha)
    | Invert -> Filter.controls (name Invert)
    | Grayscale -> Filter.controls (name Grayscale)
    | Sepia -> Filter.controls (name Sepia)
    | Nightvision -> Filter.controls (name Nightvision)
    | Warm -> Filter.controls (name Warm)
    | Cool -> Filter.controls (name Cool)
    | Brightness -> Filter.controls (name Brightness)
    | Exposure -> Filter.controls (name Exposure)
    | Contrast -> Filter.controls (name Contrast)
    | Temperature -> Filter.controls (name Temperature)
    | Tint -> Filter.controls (name Tint)
    | Threshold -> Filter.controls (name Threshold)
    | Technicolor -> Filter.controls (name Technicolor)
    | Polaroid -> Filter.controls (name Polaroid)
    | ToBGR -> Filter.controls (name ToBGR)
    | Kodachrome -> Filter.controls (name Kodachrome)
    | Browni -> Filter.controls (name Browni)
    | Vintage -> Filter.controls (name Vintage)
    | Night -> Filter.controls (name Night)
    | Predator -> Filter.controls (name Predator)
    | Lsd -> Filter.controls (name Lsd)
    | ColorTone -> Filter.controls (name ColorTone)
    | Protanomaly -> Filter.controls (name Protanomaly)
    | Deuteranomaly -> Filter.controls (name Deuteranomaly)
    | Tritanomaly -> Filter.controls (name Tritanomaly)
    | Protanopia -> Filter.controls (name Protanopia)
    | Deuteranopia -> Filter.controls (name Deuteranopia)
    | Tritanopia -> Filter.controls (name Tritanopia)
    | Achromatopsia -> Filter.controls (name Achromatopsia)
    | Achromatomaly -> Filter.controls (name Achromatomaly)

    
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
       Technicolor
       Polaroid
       ToBGR
       Kodachrome
       Browni
       Vintage
       Night
       Predator
       Lsd
       ColorTone
       Protanomaly
       Deuteranomaly
       Tritanomaly
       Protanopia
       Deuteranopia
       Tritanopia
       Achromatopsia
       Achromatomaly |]