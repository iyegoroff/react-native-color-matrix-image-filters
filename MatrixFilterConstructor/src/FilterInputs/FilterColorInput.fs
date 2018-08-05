namespace MatrixFilterConstructor

open Elmish
open Fable.Import
open Fable.Import.ReactNativeColorWheel
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Elmish.React

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RNC = Fable.Helpers.ReactNativeColorWheel


module FilterColorInput =

  type Model =
    { Name: string
      Value: string
      ColorWheelRef: ColorWheel option }

  type Message =
    | ValueChanged of string
    | ColorWheelRefChanged of ColorWheel

  let init name initial : Model =
    { Name = name
      Value = initial
      ColorWheelRef = None }

  let update (message: Message) (model: Model) : Model * Sub<Message> list =
    match message with
    | ValueChanged value -> 
      { model with Value = value }, []

    | ColorWheelRefChanged value -> 
      { model with ColorWheelRef = Some value }, []

  let private containerStyle =
    ViewProperties.Style
      [ BorderWidth 1.
        BorderRadius 3.
        Padding (dip 3.)
        MarginBottom (dip 3.)
        BackgroundColor "white" ]

  let private colorWheelStyle =
    RNC.Props.Style
      [ Width (dip 235.)
        Height (dip 200.)
        AlignSelf Alignment.Center
        Flex 1. ]

  let view (model: Model) (dispatch: Dispatch<Message>) : React.ReactElement =
    let wheel =
      (fun () ->
         RNC.colorWheel
           [ colorWheelStyle
             RNC.Props.Ref (ColorWheelRefChanged >> dispatch)
             RNC.Props.InitialColor model.Value
             RNC.Props.Precision 10.
             RNC.Props.OnHexColorChange (ValueChanged >> dispatch) ])
    RN.view
      [ containerStyle ]
      [ RN.text [] (sprintf "%s %s" model.Name model.Value)
        lazyView wheel () ]
