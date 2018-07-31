namespace MatrixFilterConstructor

open Elmish
open Fable.Helpers.ReactNative.Props
open Fable.Helpers.ReactNative
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
        dispatch (SelectMessage (Select.Message.ItemSelected x))
        dispatch Hide
      | Close -> dispatch Hide
    
  let view items selected itemKey equals isVisible (dispatch: Dispatch<Message<'a>>) =
    let items = Array.map Item items
      
    RN.modal
      [ Visible isVisible
        OnRequestClose (fun () -> dispatch Hide) ]
      [ Select.view
          (Platform.select
             [ Platform.Android items
               Platform.Ios (Array.append items [| Close |]) ])
          (match selected with
           | Some x -> Some (Item x)
           | None -> None)
          (itemKeyWithClose itemKey)
          (equalsWithClose equals)
          (dispatchWithClose dispatch) ]
