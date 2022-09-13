namespace MatrixFilterConstructor

open Fable.Import
open Fable.Helpers

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RNF = Fable.Import.ReactNativeColorMatrixImageFilters
module CFI = CombinedFilterInput

module CombinedFilter =

  type Model =
    | Normal
    | RGBA
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
    | DuoTone
    | Protanomaly
    | Deuteranomaly
    | Tritanomaly
    | Protanopia
    | Deuteranopia
    | Tritanopia
    | Achromatopsia
    | Achromatomaly
    | AnimatedSaturate
    | AnimatedHueRotate
    | AnimatedBrightness
    | AnimatedContrast
    | AnimatedTemperature
    | AnimatedTint
    | AnimatedThreshold
    | AnimatedNight
    | AnimatedPredator


  let name =
    sprintf "%A"

  let init model : Filter.Model =
    match model with
    | Normal -> Filter.init []
    | RGBA ->
      Filter.init
        [ Filter.Red, CFI.initRange 0. 5. 1.
          Filter.Green, CFI.initRange 0. 5. 1.
          Filter.Blue, CFI.initRange 0. 5. 1.
          Filter.Alpha, CFI.initRange 0. 5. 1. ]
    | Saturate -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 1. ]
    | HueRotate -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 0. ]
    | LuminanceToAlpha -> Filter.init []
    | Invert -> Filter.init []
    | Grayscale -> Filter.init [ Filter.Amount, CFI.initRange 0. 1. 1. ]
    | Sepia -> Filter.init [ Filter.Amount, CFI.initRange 0. 1. 1. ]
    | Nightvision -> Filter.init []
    | Warm -> Filter.init []
    | Cool -> Filter.init []
    | Brightness -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 1. ]
    | Contrast -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 1. ]
    | Temperature -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 1. ]
    | Tint -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 0. ]
    | Threshold -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 1. ]
    | Technicolor -> Filter.init []
    | Polaroid -> Filter.init []
    | ToBGR -> Filter.init []
    | Kodachrome -> Filter.init []
    | Browni -> Filter.init []
    | Vintage -> Filter.init []
    | Night -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 0.1 ]
    | Predator -> Filter.init [ Filter.Amount, CFI.initRange -10. 10. 1. ]
    | Lsd -> Filter.init []
    | ColorTone ->
      Filter.init
        [ Filter.Desaturation, CFI.initRange -10. 10. 0.2
          Filter.Toned, CFI.initRange -10. 10. 1.5
          Filter.LightColor, CFI.initColor "#ffe580"
          Filter.DarkColor, CFI.initColor "#338000" ]
    | DuoTone ->
      Filter.init
        [ Filter.FirstColor, CFI.initColor "#ffe580" 
          Filter.SecondColor, CFI.initColor "#338000" ]
    | Protanomaly -> Filter.init []
    | Deuteranomaly -> Filter.init []
    | Tritanomaly -> Filter.init []
    | Protanopia -> Filter.init []
    | Deuteranopia -> Filter.init []
    | Tritanopia -> Filter.init []
    | Achromatopsia -> Filter.init []
    | Achromatomaly -> Filter.init []
    | AnimatedSaturate -> Filter.init [ Filter.Amount, CFI.initAnimated -10. 10. 1. ]
    | AnimatedHueRotate -> Filter.init [ Filter.Amount, CFI.initAnimated -10. 10. 0. ]
    | AnimatedBrightness -> Filter.init [ Filter.Amount, CFI.initAnimated -100. 100. 0. ]
    | AnimatedContrast -> Filter.init [ Filter.Amount, CFI.initAnimated -10. 10. 1. ]
    | AnimatedTemperature -> Filter.init [ Filter.Amount, CFI.initAnimated -10. 10. 1. ]
    | AnimatedTint -> Filter.init [ Filter.Amount, CFI.initAnimated -10. 10. 0. ]
    | AnimatedThreshold -> Filter.init [ Filter.Amount, CFI.initAnimated -100. 100. 0. ]
    | AnimatedNight -> Filter.init [ Filter.Amount, CFI.initAnimated -10. 10. 0.1 ]
    | AnimatedPredator -> Filter.init [ Filter.Amount, CFI.initAnimated -10. 10. 1. ]


  let matrix control (model: Filter.Model) =
    match control, model with
    | Normal, _ -> RNF.normal ()
    | RGBA,
      [ Filter.Red, CFI.Range red
        Filter.Green, CFI.Range green
        Filter.Blue, CFI.Range blue
        Filter.Alpha, CFI.Range alpha ] ->
        RNF.rgba red.Value green.Value blue.Value alpha.Value
    | Saturate, [ Filter.Amount, CFI.Range input ] -> RNF.saturate input.Value
    | HueRotate, [ Filter.Amount, CFI.Range input ] -> RNF.hueRotate input.Value
    | LuminanceToAlpha, _ -> RNF.luminanceToAlpha ()
    | Invert, _ -> RNF.invert ()
    | Grayscale, [ Filter.Amount, CFI.Range input ] -> RNF.grayscale input.Value
    | Sepia, [ Filter.Amount, CFI.Range input ] -> RNF.sepia input.Value
    | Nightvision, _ -> RNF.nightvision ()
    | Warm, _ -> RNF.warm ()
    | Cool, _ -> RNF.cool ()
    | Brightness, [ Filter.Amount, CFI.Range input ] -> RNF.brightness input.Value
    | Contrast, [ Filter.Amount, CFI.Range input ] -> RNF.contrast input.Value
    | Temperature, [ Filter.Amount, CFI.Range input ] -> RNF.temperature input.Value
    | Tint, [ Filter.Amount, CFI.Range input ] -> RNF.tint input.Value
    | Threshold, [ Filter.Amount, CFI.Range input ] -> RNF.threshold input.Value
    | Technicolor, _ -> RNF.technicolor ()
    | Polaroid, _ -> RNF.polaroid ()
    | ToBGR, _ -> RNF.toBGR ()
    | Kodachrome, _ -> RNF.kodachrome ()
    | Browni, _ -> RNF.browni ()
    | Vintage, _ -> RNF.vintage ()
    | Night, [ Filter.Amount, CFI.Range input ] -> RNF.night input.Value
    | Predator, [ Filter.Amount, CFI.Range input ] -> RNF.predator input.Value
    | Lsd, _ -> RNF.lsd ()
    | ColorTone, 
      [ Filter.Desaturation, CFI.Range desaturation
        Filter.Toned, CFI.Range toned
        Filter.LightColor, CFI.Color lightColor
        Filter.DarkColor, CFI.Color darkColor ] ->
        RNF.colorTone desaturation.Value toned.Value lightColor.Value darkColor.Value
    | DuoTone,
      [ Filter.FirstColor, CFI.Color firstColor
        Filter.SecondColor, CFI.Color secondColor ] ->
        RNF.duoTone firstColor.Value secondColor.Value
    | Protanomaly, _ -> RNF.protanomaly ()
    | Deuteranomaly, _ -> RNF.deuteranomaly ()
    | Tritanomaly, _ -> RNF.tritanomaly ()
    | Protanopia, _ -> RNF.protanopia ()
    | Deuteranopia, _ -> RNF.deuteranopia ()
    | Tritanopia, _ -> RNF.tritanopia ()
    | Achromatopsia, _ -> RNF.achromatopsia ()
    | Achromatomaly, _ -> RNF.achromatomaly ()
    | AnimatedSaturate, [ Filter.Amount, CFI.Animated input] -> RNF.saturate input.Animated.Value
    | AnimatedHueRotate, [ Filter.Amount, CFI.Animated input] -> RNF.hueRotate input.Animated.Value
    | AnimatedBrightness, [ Filter.Amount, CFI.Animated input] -> RNF.brightness input.Animated.Value
    | AnimatedContrast, [ Filter.Amount, CFI.Animated input] -> RNF.contrast input.Animated.Value
    | AnimatedTemperature, [ Filter.Amount, CFI.Animated input] -> RNF.temperature input.Animated.Value
    | AnimatedTint, [ Filter.Amount, CFI.Animated input] -> RNF.tint input.Animated.Value
    | AnimatedThreshold, [ Filter.Amount, CFI.Animated input] -> RNF.threshold input.Animated.Value
    | AnimatedNight, [ Filter.Amount, CFI.Animated input] -> RNF.night input.Animated.Value
    | AnimatedPredator, [ Filter.Amount, CFI.Animated input] -> RNF.predator input.Animated.Value
    | _ -> RNF.normal ()


  let controls (model: Model) =
    Filter.controls (name model)
    
  let availableFilters: Model array =
    [| Normal
       RGBA
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
       DuoTone
       Protanomaly
       Deuteranomaly
       Tritanomaly
       Protanopia
       Deuteranopia
       Tritanopia
       Achromatopsia
       Achromatomaly |]

  let availableAnimatedFilters: Model array =
    [| AnimatedSaturate
       AnimatedHueRotate
       AnimatedBrightness
       AnimatedContrast
       AnimatedTemperature
       AnimatedTint
       AnimatedThreshold
       AnimatedNight
       AnimatedPredator |]
       