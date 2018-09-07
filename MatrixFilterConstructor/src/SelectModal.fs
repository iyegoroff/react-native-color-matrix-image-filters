namespace MatrixFilterConstructor

open Elmish
open Fable.Helpers.ReactNative.Props
open Fable.Helpers.ReactNative
open Fable.Import.ReactNative
open Fable.Core
open Fable.Import

module RN = Fable.Helpers.ReactNative


module SelectModal =

  type Message<'a> =
    | Hide
    | SelectMessage of Select.Message<'a>

  type WithClose<'a> =
    | Item of 'a
    | Close

  let private itemKeyWithClose itemKey =
    function
    | Item x -> itemKey x
    | Close -> "❌"

  let private equalsWithClose equals first second =
    match first, second with
    | Item x, Item y -> equals x y
    | Close, Close -> true
    | _ -> false

  let private dispatchWithClose dispatch =
    function
    | Select.Message.ItemSelected item ->
      match item with
      | Item x ->
        dispatch Hide
        (fun () ->
           JS.setTimeout (fun () -> dispatch (SelectMessage (Select.Message.ItemSelected x))) 50
           |> ignore
           |> U2.Case1)
        |> Globals.InteractionManager.runAfterInteractions
        |> ignore
      | Close -> dispatch Hide
    
  let view items selected itemKey equals isVisible (dispatch: Dispatch<Message<'a>>) =
    let items = Array.map Item items
      
    RN.modal
      [ AnimationType
          (Platform.select
             [ Platform.Ios AnimationType.Slide
               Platform.Android AnimationType.Fade ])
        ModalProperties.Visible isVisible
        OnRequestClose (fun () -> dispatch Hide) ]
      [ Select.view
          (Platform.select
             [ Platform.Android items
               Platform.Ios (Array.append items [| Close |]) ])
          (Option.map Item selected)
          (itemKeyWithClose itemKey)
          (equalsWithClose equals)
          (dispatchWithClose dispatch) ]
