namespace MatrixFilterConstructor

open Elmish
open Elmish.React
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Import

module RN = Fable.Helpers.ReactNative
module R = Fable.Helpers.React
module RNP = Fable.Import.ReactNativePortal


module Main =

  type Id = int

  type Model =
    { FilteredImages: (Id * FilteredImage.Model) array
      DefaultImageSelectModalIsVisible: bool
      DefaultImage: Image.Model
      NextId: Id }

  type Message =
    | AddFilteredImage
    | SelectDefaultImage
    | ImageSelectModalMessage of ImageSelectModal.Message
    | FilteredImageMessage of Id * FilteredImage.Message

  let init () = 
    // Utils.enableExperimentalLayoutAnimationOnAndroid ()
    { FilteredImages = [||]
      DefaultImageSelectModalIsVisible = false
      DefaultImage = Image.defaultImage
      NextId = 0 },
    Cmd.none

  let update (message: Message) model =
    match message with
    | AddFilteredImage ->
      Utils.configureNextLayoutAnimation ()
      let newImage = FilteredImage.init model.DefaultImage
      { model with FilteredImages = Array.append [| (model.NextId, newImage) |] model.FilteredImages
                   NextId = model.NextId + 1 }, []

    | SelectDefaultImage ->
      { model with DefaultImageSelectModalIsVisible = true }, []

    | ImageSelectModalMessage msg ->
      match msg with
      | ImageSelectModal.ImageSelectionSucceed image ->
        { model with DefaultImage = image },
        model.FilteredImages
        |> Array.map
             (fun (id, _) ->
                Cmd.map
                  (fun sub -> FilteredImageMessage (id, sub))
                  (Cmd.ofMsg (FilteredImage.SetImage image)))
        |> Cmd.batch
      | ImageSelectModal.ImageSelectionCancelled ->
        model, []
      | ImageSelectModal.ImageSelectionFailed message ->
        Alert.alert ("Error", message, [])
        model, []
      | ImageSelectModal.Hide ->
        { model with DefaultImageSelectModalIsVisible = false }, []

    | FilteredImageMessage (id, msg) ->
      match Array.tryFind (fun (i, _) -> i = id) model.FilteredImages with
      | None -> model, []
      | Some (_, image) ->
        match msg with
        | FilteredImage.Delete ->
          Utils.configureNextLayoutAnimation ()
          { model with FilteredImages = Array.filter
                                          (fun (i, _) -> i <> id)
                                          model.FilteredImages }, []
        | _ ->
          let image', cmd = FilteredImage.update msg image
          { model with FilteredImages = Array.map
                                          (fun (i, m) -> i, if i = id then image' else m)
                                          model.FilteredImages },
          Cmd.map (fun sub -> FilteredImageMessage (id, sub)) cmd

  let private separatorStyle =
    ViewProperties.Style
      [ Height (dip 1.5) ]

  let private listContentStyle =
    FlatListProperties.ContentContainerStyle
      [ Padding (pct 1.5)
        PaddingTop 
          (Platform.select
            [ Platform.Ios (dip 25.)
              Platform.Android (dip 5.) ]) ]

  let private listStyle =
    FlatListProperties.Style
      [ BackgroundColor "wheat" ]

  let separator () =
    RN.view [ separatorStyle ] []
        
  let view model (dispatch: Dispatch<Message>) =
    let filteredImageDispatch i msg = dispatch <| FilteredImageMessage (i, msg)

    let renderFilteredImage (id, image) =
      FilteredImage.view image (filteredImageDispatch id)

    let listControls () =
      R.fragment
        []
        [ RN.button
            [ ButtonProperties.Title "Change all images"
              ButtonProperties.Color "green"
              ButtonProperties.OnPress (fun () -> dispatch SelectDefaultImage) ]
            []
          Spacer.view 5.
          RN.button
            [ ButtonProperties.Title "Add filtered image"
              ButtonProperties.Color "green"
              ButtonProperties.OnPress (fun () -> dispatch AddFilteredImage) ]
            [] ]

    RNP.portalProvider
      [ ImageSelectModal.view
          model.DefaultImage
          model.DefaultImageSelectModalIsVisible
          (ImageSelectModalMessage >> dispatch)
        RNP.exitPortal Constants.filterPortal []
        RNP.exitPortal Constants.imagePortal []
        RN.flatList model.FilteredImages
          [ listContentStyle
            listStyle
            RenderItem (fun item -> lazyView renderFilteredImage item.item)
            ItemSeparatorComponent separator
            ListHeaderComponent listControls
            KeyExtractor (fun (id, _) _ -> string id) ] ]
