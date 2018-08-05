namespace MatrixFilterConstructor

open Elmish
open Fable.Import

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative


module CombinedFilterInput =

  type Shape<'range, 'color> =
    | Range of 'range
    | Color of 'color

  type Model = Shape<FilterRangeInput.Model,
                     FilterColorInput.Model>

  type Message = Shape<FilterRangeInput.Message,
                       FilterColorInput.Message>
  

  let initRange min max name =
    Range (FilterRangeInput.init name min max)
    
  let initColor name =
    Color (FilterColorInput.init name "#ffffff")

  let update (message: Message) (model: Model) : Model * Sub<Message> list =
    match (model, message) with
    | Range model', Range message' ->
      let m, cmd = FilterRangeInput.update message' model'
      (Range m), Cmd.map Range cmd
    | Range _, _ -> model, []

    | Color model', Color message' ->
      let m, cmd = FilterColorInput.update message' model'
      (Color m), Cmd.map Color cmd
    | Color _, _ -> model, []

  let view (model: Model) (dispatch: Dispatch<Message>) : React.ReactElement =
    match model with
    | Range model' -> FilterRangeInput.view model' (Range >> dispatch)
    | Color model' -> FilterColorInput.view model' (Color >> dispatch)
