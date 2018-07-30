namespace MatrixFilterConstructor

open Elmish
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative


module FilterControl =

  type Model = FilterRangeInput.Model option

  type Message =
    | FilterInputMessage of FilterRangeInput.Message
    | MoveUp
    | MoveDown
    | Delete


  let update (message: Message) (model: Model) : Model * Sub<Message> list =
    match message with
    | FilterInputMessage msg ->
      match model with
      | Some input ->
        let input', cmd = FilterRangeInput.update msg input
        Some input', Cmd.map FilterInputMessage cmd
      | None -> model, []

    | MoveUp
    | MoveDown
    | Delete -> model, []

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

  let view name (model: Model) (dispatch: Dispatch<Message>) =
    let slider =
      match model with
      | Some input -> FilterRangeInput.view input (FilterInputMessage >> dispatch)
      | _ -> R.fragment [] []
        
    RN.view
      [ controlsContainer ]
      [ RN.text [ titleStyle ] name
        slider
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
