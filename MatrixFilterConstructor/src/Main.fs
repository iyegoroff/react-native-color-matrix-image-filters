namespace MatrixFilterConstructor

open Elmish
open Elmish.React
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open SelectModal
open Select
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
    | ChangeAllImages
    | FilteredImageMessage of Id * FilteredImage.Message
    | ImageSelectModalMessage of ImageSelectModal.Message
    | ContainerScrolled


  let init () = 
    { FilteredImages = [||]
      DefaultImageSelectModalIsVisible = false
      DefaultImage = Image.defaultImage
      NextId = 0 },
    Cmd.none

  let update (message: Message) model =
    match message with
    | AddFilteredImage ->
      { model with FilteredImages =
                     Array.append
                       [| (model.NextId, FilteredImage.init model.DefaultImage) |]
                       model.FilteredImages
                   NextId = model.NextId + 1 }, []

    | ChangeAllImages ->
      { model with DefaultImageSelectModalIsVisible = true }, []

    | FilteredImageMessage (id, msg) ->
      match Array.tryFind (fun (i, _) -> i = id) model.FilteredImages with
      | None -> model, []
      | Some (_, image) ->
        match msg with
        | FilteredImage.Delete ->
          { model with FilteredImages = Array.filter
                                          (fun (i, _) -> i <> id)
                                          model.FilteredImages }, []
        | _ ->
          let image', cmd = FilteredImage.update msg image
          { model with FilteredImages = Array.map
                                          (fun (i, m) -> i, if i = id then image' else m)
                                          model.FilteredImages },
          Cmd.map (fun sub -> FilteredImageMessage (id, sub)) cmd

    | ImageSelectModalMessage msg ->
      match msg with
      | SelectMessage (ItemSelected image) ->
        let filteredImages =
          Array.map (fun (i, m) -> i, (FilteredImage.selectImage m image)) model.FilteredImages
        { model with DefaultImage = image 
                     FilteredImages = filteredImages }, []
      | Hide ->
        { model with DefaultImageSelectModalIsVisible = false }, []

    | ContainerScrolled ->
      model, []


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
              ButtonProperties.OnPress (fun () -> dispatch ChangeAllImages) ]
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
            OnMomentumScrollEnd (fun _ -> dispatch ContainerScrolled)
            OnScrollEndDrag (fun _ -> dispatch ContainerScrolled)
            KeyExtractor (fun (id, _) _ -> string id) ] ]
