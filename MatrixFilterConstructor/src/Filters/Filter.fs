namespace MatrixFilterConstructor

open Elmish
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RNF = Fable.Import.ReactNativeColorMatrixImageFilters


module Filter =

  type Input =
    | Amount
    | Desaturation
    | Toned
    | LightColor
    | DarkColor
    | Red
    | Green
    | Blue
    | Alpha
    | FirstColor
    | SecondColor

  type Model = (Input * CombinedFilterInput.Model) list

  type Message =
    | FilterInputMessage of Input * CombinedFilterInput.Message
    | MoveUp
    | MoveDown
    | Delete
    | Tick

  let init inputs : Model =
    List.map
      (fun (input, toModel) -> input, toModel (sprintf "%A" input))
      inputs

  let update (message: Message) (model: Model) : Model * Sub<Message> list =
    match message with
    | FilterInputMessage (input, msg) ->
      match List.tryFind (fun (id, _) -> input = id) model with
      | Some (_, inputModel) ->
        let inputModel', cmd = CombinedFilterInput.update msg inputModel
        List.map (fun (id, m) -> id, if input = id then inputModel' else m) model,
        Cmd.map (fun sub -> FilterInputMessage (input, sub)) cmd
      | None -> model, []

    | MoveUp
    | MoveDown
    | Delete -> model, []

    | Tick ->
      model,
      model
      |> List.map
           (fun (input, _) ->
              Cmd.map
                (fun sub -> FilterInputMessage (input, sub))
                (Cmd.ofMsg (CombinedFilterInput.Animated AnimatedFilterRangeInput.Tick)))
      |> Cmd.batch

  let private controlsContainer =
    ViewProperties.Style
      [ Padding (dip 3.)
        MarginBottom (dip 2.)
        BorderRadius 3. 
        BorderWidth 1. 
        BackgroundColor "gainsboro" ]

  let private titleStyle =
    TextProperties.Style
      [ FontWeight FontWeight.Bold ]

  let private controlButtonsStyle =
    ViewProperties.Style
      [ FlexDirection FlexDirection.Row
        JustifyContent JustifyContent.SpaceBetween ]

  let view filterComponent mapInput (model: Model) content =
    filterComponent
      (model |> List.map mapInput |> List.choose id)
      [ content ]

  let controls name (model: Model) (dispatch: Dispatch<Message>) =
    let dispatch' = FilterInputMessage >> dispatch
    let sliders = 
      List.map
        (fun (input, inputModel) ->
           CombinedFilterInput.view inputModel (fun msg -> dispatch' (input, msg)))
        model
        
    RN.view
      [ controlsContainer ]
      [ RN.text [ titleStyle ] name
        R.fragment [] sliders
        RN.view
          [ controlButtonsStyle ]
          [ RN.button
              [ ButtonProperties.Title "Move Up"
                ButtonProperties.OnPress (fun () -> dispatch MoveUp) ]
              []
            RN.button
              [ ButtonProperties.Title "Move Down"
                ButtonProperties.OnPress (fun () -> dispatch MoveDown) ]
              []
            RN.button
              [ ButtonProperties.Title "Delete"
                ButtonProperties.Color "red"
                ButtonProperties.OnPress (fun () -> dispatch Delete) ]
              [] ] ]
