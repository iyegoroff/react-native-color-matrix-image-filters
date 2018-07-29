namespace FilterConstructor

open Elmish
open Image
open SelectModal
open Select


module ImageSelectModal =

  type Message = SelectModal.Message<Image.Model>


  let view image isVisible (dispatch: Dispatch<Message>) =
    let dispatch' =
      function
      | (SelectMessage (ItemSelected (Random _))) ->
        dispatch (SelectMessage (ItemSelected (Image.random ())))
      | x -> dispatch x

    SelectModal.view Image.availableImages (Some image) Image.name Image.equals isVisible dispatch'
