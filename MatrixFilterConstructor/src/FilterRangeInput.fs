namespace MatrixFilterConstructor

open Elmish
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Import

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative


module FilterRangeInput =

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

  let view (model: Model) (dispatch: Dispatch<Message>) =
    RN.view
      [ containerStyle ]
      [ RN.text [] (sprintf "Value %.2f" model.Value)
        RN.slider
          [ MaximumValue model.Max
            MinimumValue model.Min
            SliderProperties.OnValueChange (ValueChanged >> dispatch) ]
        RN.view
          [ rangeLegendStyle ]
          [ RN.text [] (sprintf "%.2f" model.Min)
            RN.text [] (sprintf "%.2f" model.Max) ] ]
