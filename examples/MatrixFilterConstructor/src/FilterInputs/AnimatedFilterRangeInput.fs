namespace MatrixFilterConstructor

open Elmish
open Elmish.React
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Import.JS
open Fable.Import

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RS = Fable.Import.ReactNativeSlider


module AnimatedFilterRangeInput =

  type Model =
    { Animated: FilterRangeInput.Model
      Step: FilterRangeInput.Model
      Direction: float } 

  type Message =
    | StepMessage of FilterRangeInput.Message
    | Tick

  let init name min max initial : Model =
    let minStep = ((Math.abs max) / 1000.)
    let maxStep = ((Math.abs max) / 10.)
    { Animated = FilterRangeInput.init name min max initial
      Step = FilterRangeInput.init (sprintf "Step.%s" name) minStep maxStep minStep
      Direction = 1. }

  let update (message: Message) (model: Model) =
    match message with
    | StepMessage stepMessage ->
      let step, stepCmd = FilterRangeInput.update stepMessage model.Step
      { model with Step = step }, Cmd.map StepMessage stepCmd

    | Tick ->
      let animated = model.Animated
      let nextValue =
        Math.max
          [| animated.Min
             Math.min [| animated.Max; animated.Value + (model.Direction * model.Step.Value)|] |]
      let nextDirection =
        if nextValue = animated.Min then 1. elif nextValue = animated.Max then -1. else model.Direction

      { model with Direction = nextDirection
                   Animated = { animated with Value = nextValue } }, []


  let view (model: Model) (dispatch: Dispatch<Message>) =
    R.fragment
      []
      [ FilterRangeInput.disabledView model.Animated
        FilterRangeInput.view model.Step (StepMessage >> dispatch) ]
