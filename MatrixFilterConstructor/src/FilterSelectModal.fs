namespace MatrixFilterConstructor

open Elmish

module FilterSelectModal =

  type Message = SelectModal.Message<CombinedFilter.Model>

  let private view filters isVisible (dispatch: Dispatch<Message>) =
    SelectModal.view filters None CombinedFilter.name (=) isVisible dispatch

  let common = 
    view CombinedFilter.availableFilters

  let animated =
    view CombinedFilter.availableAnimatedFilters
