namespace MatrixFilterConstructor

open Elmish
open Elmish.React
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Import

module RN = Fable.Helpers.ReactNative


module Select =

  type Message<'a> =
    | ItemSelected of 'a

  let private itemStyle =
    ViewProperties.Style
      [ Padding (dip 15.) ]

  let private selectedStyle =
    TextProperties.Style
      [ FontWeight FontWeight.Bold
        TextDecorationLine TextDecorationLine.Underline ]

  let private separatorStyle =
    ViewProperties.Style
      [ Height (dip 1.)
        Width (pct 95.)
        AlignSelf Alignment.Center
        BackgroundColor "lightgray" ]
    

  let private separator () =
    RN.view [ separatorStyle ] []

  let private touchable =
    Platform.select
      [ Platform.Ios (fun onPress -> RN.touchableOpacity [ OnPress onPress ])
        Platform.Android (fun onPress -> RN.touchableNativeFeedback [ OnPress onPress ]) ]

  let view items selected itemKey equals (dispatch: Dispatch<Message<'a>>) =
    let renderItem item =
      let style = match selected with
                  | Some sel when (equals item sel) -> [ selectedStyle ]
                  | _ -> []
      touchable
        (fun () -> dispatch (ItemSelected item))
        [ RN.view
            [ itemStyle ]
            [ RN.text
                style
                (itemKey item) ] ]

    RN.flatList items
      [ RenderItem (fun item -> lazyView renderItem item.item)
        ItemSeparatorComponent separator
        ExtraData selected
        KeyExtractor (fun item _ -> itemKey item) ]
