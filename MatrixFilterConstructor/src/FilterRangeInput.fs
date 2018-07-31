namespace MatrixFilterConstructor

open Elmish
open Elmish.React
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Import

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RS = Fable.Import.ReactNativeSlider


module FilterRangeInput =

  type private Size =
    { width: float 
      height: float }

  type Model =
    { Value: float
      Min: float
      Max: float }

  type Message =
    | ValueChanged of float

  let init min max : Model =
    { Min = min
      Max = max
      Value = 0. }

  let update (message: Message) (model: Model) =
    match message with
    | ValueChanged value ->
      { model with Value = value }, []


  let private containerStyle =
    ViewProperties.Style
      [ BorderWidth 1.
        BorderRadius 3.
        Padding (dip 3.)
        MarginBottom (dip 3.)
        BackgroundColor "white" ]

  let private rangeLegendStyle =
    ViewProperties.Style
      [ FlexDirection FlexDirection.Row
        JustifyContent JustifyContent.SpaceBetween ]

  let private thumbStyle =
    RS.Props.ThumbStyle
      [ ShadowColor "black"
        ShadowRadius 1.
        ShadowOpacity 1.
        ShadowOffset
          { width = 0.
            height = 0. }
        BackgroundColor "white"
        Elevation 2. ]

  let view (model: Model) (dispatch: Dispatch<Message>) =
    RN.view
      [ containerStyle ]
      [ RN.text [] (sprintf "Value %.2f" model.Value)
        (Platform.select
          [ Platform.Android
              (RN.slider
                [ MaximumValue model.Max
                  MinimumValue model.Min
                  SliderProperties.OnValueChange (ValueChanged >> dispatch) ])
            Platform.Ios
              (RS.slider
                [ thumbStyle
                  RS.Props.MaximumValue model.Max
                  RS.Props.MinimumValue model.Min
                  RS.Props.MinimumTrackTintColor "#007aff"
                  RS.Props.OnValueChange (ValueChanged >> dispatch) ]) ]) 
        RN.view
          [ rangeLegendStyle ]
          [ RN.text [] (sprintf "%.2f" model.Min)
            RN.text [] (sprintf "%.2f" model.Max) ] ]
