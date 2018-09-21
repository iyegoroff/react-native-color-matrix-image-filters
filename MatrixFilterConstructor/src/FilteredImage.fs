namespace MatrixFilterConstructor

open Elmish
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open SelectModal
open Select
open Fable.Import
open Fable.Import.ReactNative

module R = Fable.Helpers.React
module RN = Fable.Helpers.ReactNative
module RNP = Fable.Import.ReactNativePortal
module RNF = Fable.Import.ReactNativeColorMatrixImageFilters
module RNS = Fable.Helpers.ReactNativeSegmentedControlTab


module FilteredImage =

  type Id = int

  type Loading =
    | InProgress
    | Failed
    | Done

  type Model = 
    { Image: Image.Model
      Filters: (Id * CombinedFilter.Model * Filter.Model) list
      ImageSelectModalIsVisible: bool
      CommonFilterSelectModalIsVisible: bool
      AnimatedFilterSelectModalIsVisible: bool
      SelectedResizeMode: ResizeMode
      LoadingStatus: Loading
      NextId: Id }

  type Message =
    | Delete
    | SelectImage
    | SetImage of Image.Model
    | ImageSelectModalMessage of ImageSelectModal.Message
    | SelectCommonFilter
    | SelectAnimatedFilter
    | FilterSelectModalMessage of FilterSelectModal.Message
    | FilterMessage of Id * Filter.Message
    | ResizeModeChanged of int
    | CopyCode
    | ImageLoadingStarted
    | ImageLoadingSucceed
    | ImageLoadingFailed
    | Tick


  let private resizeModes =
    [| ResizeMode.Contain
       ResizeMode.Cover
       ResizeMode.Stretch
       ResizeMode.Center
       ResizeMode.Repeat |]

  let private resizeControlValues = new ResizeArray<string> (Array.map unbox<string> resizeModes)

  let init image =
    { Image = image
      Filters = []
      ImageSelectModalIsVisible = false 
      CommonFilterSelectModalIsVisible = false
      AnimatedFilterSelectModalIsVisible = false
      SelectedResizeMode = ResizeMode.Contain
      LoadingStatus = Done
      NextId = 0 }

  let private resizeControlIndex model =
    defaultArg (Array.tryFindIndex (fun x -> x = model.SelectedResizeMode) resizeModes) 0

  let update (message: Message) model =
    match message with
    | Delete ->
      model, []
      
    | SelectImage  -> 
      { model with ImageSelectModalIsVisible = true }, []

    | SetImage image -> 
      { model with Image = image }, []

    | ImageSelectModalMessage msg ->
      match msg with
      | ImageSelectModal.ImageSelectionSucceed image ->
        model, Cmd.ofMsg (SetImage image)
      | ImageSelectModal.ImageSelectionCancelled ->
        model, []
      | ImageSelectModal.ImageSelectionFailed message ->
        Alert.alert ("Error", message, [])
        model, []
      | ImageSelectModal.Hide ->
        { model with ImageSelectModalIsVisible = false }, []

    | SelectCommonFilter ->
      { model with CommonFilterSelectModalIsVisible = true }, []

    | SelectAnimatedFilter ->
      { model with AnimatedFilterSelectModalIsVisible = true }, []

    | FilterSelectModalMessage msg ->
      match msg with
      | SelectMessage (ItemSelected filter) -> 
        Utils.configureNextLayoutAnimation ()
        { model with Filters = model.Filters @ [model.NextId, filter, CombinedFilter.init filter]
                     NextId = model.NextId + 1 }, []
      | Hide ->
        { model with CommonFilterSelectModalIsVisible = false
                     AnimatedFilterSelectModalIsVisible = false }, []

    | FilterMessage (id, msg) ->
      match List.tryFind (fun (i, _, _) -> i = id) model.Filters with
      | None -> model, []
      | Some (_, _, filter) ->
        let filter', cmd = Filter.update msg filter
        let filters =
          List.map (fun (i, t, f) -> i, t, if i = id then filter' else f) model.Filters
        let filters' =
          match msg with
          | Filter.Delete ->
            Utils.configureNextLayoutAnimation ()
            List.filter (fun (i, _, _) -> i <> id) filters
          | Filter.MoveDown ->
            Utils.configureNextLayoutAnimation ()
            Utils.moveUpAt (List.findIndex (fun (i, _, _) -> i = id) filters) filters
          | Filter.MoveUp ->
            Utils.configureNextLayoutAnimation ()
            Utils.moveDownAt (List.findIndex (fun (i, _, _) -> i = id) filters) filters
          | _ -> filters

        { model with Filters = filters' },
        Cmd.map (fun sub -> FilterMessage (id, sub)) cmd

    | ResizeModeChanged index ->
      { model with SelectedResizeMode = resizeModes.[index] }, []

    | CopyCode ->
      model.Filters
      |> List.map (fun (_, filter, value) -> (filter, value))
      |> JSGenerator.run
      |> Globals.Clipboard.setString

      Alert.alert ("Info", "JS code copied to clipboard", [])
      model, []

    | ImageLoadingStarted ->
      { model with LoadingStatus = InProgress }, []

    | ImageLoadingSucceed ->
      { model with LoadingStatus = Done }, []

    | ImageLoadingFailed ->
      { model with LoadingStatus = Failed }, []

    | Tick ->
      model,
      model.Filters
      |> List.map
           (fun (id, _, _) -> Cmd.map (fun sub -> FilterMessage (id, sub)) (Cmd.ofMsg Filter.Tick))
      |> Cmd.batch
      

  let private containerStyle =
    ViewProperties.Style
      [ MarginTop (dip 5.)
        Padding (dip 5.)
        BorderWidth 2.
        BorderRadius 3.
        BackgroundColor "white" ]

  let private imageStyle =
    ImageProperties.Style
      [ MarginBottom (dip 5.)
        Width (pct 100.)
        Height (dip Constants.imageHeight) ]

  let private controlsStyle =
    ViewProperties.Style
      [ MarginTop (dip 10.)
        FlexDirection FlexDirection.Row
        JustifyContent JustifyContent.SpaceBetween ]

  let private spinnerStyle =
    ViewProperties.Style
      [ Position Position.Absolute
        Width (pct 100.) 
        Height (pct 100.)
        JustifyContent JustifyContent.Center 
        AlignItems ItemAlignment.Center ]

  let private filterContainerStyle =
    ViewProperties.Style
      [ FlexDirection FlexDirection.ColumnReverse ]
    
  let private combinedMatrix model =
    model.Filters
    |> List.map (fun (_, control, model) -> CombinedFilter.matrix control model)
    |> List.toArray
    |> function
       | [||] -> RNF.normal ()
       | x -> RNF.concatColorMatrices x
      
  let view model (dispatch: Dispatch<Message>) =
    R.fragment
      []
      [ RNP.enterPortal
          Constants.imagePortal
          [ ImageSelectModal.view
              model.Image
              model.ImageSelectModalIsVisible
              (ImageSelectModalMessage >> dispatch) ]
        RNP.enterPortal
          Constants.commonFilterPortal
          [ FilterSelectModal.common
              model.CommonFilterSelectModalIsVisible
              (FilterSelectModalMessage >> dispatch) ]
        RNP.enterPortal
          Constants.animatedFilterPortal
          [ FilterSelectModal.animated
              model.AnimatedFilterSelectModalIsVisible
              (FilterSelectModalMessage >> dispatch) ]
        RN.view
          [ containerStyle
            ActivityIndicator.Size Size.Large ]
          [ RN.button
              [ ButtonProperties.Title "Add filter"
                ButtonProperties.OnPress (fun _ -> dispatch SelectCommonFilter) ]
              []
            Spacer.view
            RN.button
              [ ButtonProperties.Title "Add animated filter"
                ButtonProperties.OnPress (fun _ -> dispatch SelectAnimatedFilter) ]
              []
            Spacer.view
            RN.view
              [ filterContainerStyle ]
              (List.map
                 (fun (id, tag, filter) ->
                    R.fragment
                      [ R.Props.FragmentProp.Key (string id) ]
                      [ CombinedFilter.controls
                          tag
                          filter
                          (fun msg -> dispatch (FilterMessage (id, msg))) ])
                 model.Filters)
            RN.view
              []
              [ (match model.LoadingStatus with
                 | InProgress -> RN.activityIndicator [ spinnerStyle ]
                 | Done -> R.fragment [] []
                 | Failed -> RN.view [ spinnerStyle ] [ RN.text [] "🚫" ])
                (match (Image.source model.Image) with
                 | None -> R.fragment [] []
                 | Some source ->
                   RNF.ColorMatrix
                     [ RNF.Props.ColorMatrixProps.Matrix (combinedMatrix model) ]
                     [ RN.image
                         [ imageStyle
                           OnLoadStart (fun _ -> dispatch ImageLoadingStarted)
                           OnLoad (fun _ -> dispatch ImageLoadingSucceed)
                           OnError (fun _ -> dispatch ImageLoadingFailed)
                           ResizeMode model.SelectedResizeMode
                           Source source ] ]) ]
            (Platform.select
              [ Platform.Android
                  (RNS.segmentedControlTab
                    [ RNS.Props.Values resizeControlValues
                      RNS.Props.OnTabPress (ResizeModeChanged >> dispatch)
                      RNS.Props.SelectedIndex (resizeControlIndex model) ])
                Platform.Ios
                  (RN.segmentedControlIOS
                     [ Values resizeControlValues
                       SegmentedControlIOSProperties.OnChange
                         (fun event ->
                            dispatch (ResizeModeChanged event.nativeEvent.selectedSegmentIndex))
                       SelectedIndex (resizeControlIndex model) ] )])
            RN.view
              [ controlsStyle ]
              [ RN.button
                  [ ButtonProperties.Title "Copy JS"
                    ButtonProperties.OnPress (fun _ -> dispatch CopyCode) ]
                  [] 
                RN.button
                  [ ButtonProperties.Title "Change image"
                    ButtonProperties.OnPress (fun _ -> dispatch SelectImage) ]
                  [] 
                RN.button
                  [ ButtonProperties.Title "Delete"
                    ButtonProperties.Color "red"
                    ButtonProperties.OnPress (fun _ -> dispatch Delete) ]
                  [] ] ] ]
