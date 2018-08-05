namespace MatrixFilterConstructor

open Elmish
open Fable.Import

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative


module CombinedFilterInput =

  type Shape<'range, 'color, 'animated> =
    | Range of 'range
    | Color of 'color
    | Animated of 'animated

  type Model = Shape<FilterRangeInput.Model,
                     FilterColorInput.Model,
                     AnimatedFilterRangeInput.Model>

  type Message = Shape<FilterRangeInput.Message,
                       FilterColorInput.Message,
                       AnimatedFilterRangeInput.Message>
  

  let initRange min max initial name =
    Range (FilterRangeInput.init name min max initial)
    
  let initColor initial name =
    Color (FilterColorInput.init name initial)

  let initAnimated min max initial name =
    Animated (AnimatedFilterRangeInput.init name min max initial)

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

    | Animated model', Animated message' ->
      let m, cmd = AnimatedFilterRangeInput.update message' model'
      (Animated m), Cmd.map Animated cmd
    | Animated _, _ -> model, []

  let view (model: Model) (dispatch: Dispatch<Message>) : React.ReactElement =
    match model with
    | Range model' -> FilterRangeInput.view model' (Range >> dispatch)
    | Color model' -> FilterColorInput.view model' (Color >> dispatch)
    | Animated model' -> AnimatedFilterRangeInput.view model' (Animated >> dispatch)
