namespace MatrixFilterConstructor

open Elmish
open FilterControl
open SelectModal
open Select


module FilterSelectModal =

  type Message = SelectModal.Message<CombinedFilterControl.Model>


  let view isVisible (dispatch: Dispatch<Message>) =
    SelectModal.view CombinedFilterControl.availableFilters None CombinedFilterControl.name (=) isVisible dispatch
