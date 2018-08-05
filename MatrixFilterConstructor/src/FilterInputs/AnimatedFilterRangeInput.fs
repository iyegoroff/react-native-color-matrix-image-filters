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
    { Value: float
      Min: float
      Max: float
      Name: string
      Direction: float
      Step: FilterRangeInput.Model } 

  type Message =
    | StepMessage of FilterRangeInput.Message
    | Tick

  let init name min max initial : Model =
    let minStep = ((Math.abs max) / 1000.)
    let maxStep = ((Math.abs max) / 10.)
    { Min = min
      Max = max
      Value = initial
      Name = name
      Direction = 1.
      Step = FilterRangeInput.init (sprintf "%s.Step" name) minStep maxStep minStep }

  let update (message: Message) (model: Model) =
    match message with
    | StepMessage stepMessage ->
      let step, stepCmd = FilterRangeInput.update stepMessage model.Step
      { model with Step = step }, Cmd.map StepMessage stepCmd

    | Tick ->
      let nextValue =
        Math.max
          [| model.Min
             Math.min [| model.Max; model.Value + (model.Direction * model.Step.Value)|] |]
      let nextDirection =
        if nextValue = model.Min then 1. elif nextValue = model.Max then -1. else model.Direction

      { model with Value = nextValue
                   Direction = nextDirection }, []


  let view (model: Model) (dispatch: Dispatch<Message>) =
    FilterRangeInput.view model.Step (StepMessage >> dispatch)
