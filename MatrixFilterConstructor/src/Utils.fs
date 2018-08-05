namespace MatrixFilterConstructor

open Fable.Import.ReactNative

module Utils =

  let rec moveDownAt index list =
    match index, list with
    | -1, _ -> list
    | 0, first::second::tail -> second::first::tail
    | index, first::tail -> first::moveDownAt (index - 1) tail
    | _, [] -> list

  let moveUpAt index list = moveDownAt (index - 1) list

  let configureNextLayoutAnimation () =
    Globals.LayoutAnimation.spring id
