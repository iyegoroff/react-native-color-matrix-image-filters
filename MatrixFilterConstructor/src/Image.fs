namespace MatrixFilterConstructor

open Fable.Helpers.ReactNative.Props
open Fable.Helpers.ReactNative
open Fable.Import

module Image =

  type Model' =
    { Name: string
      Source: IImageSource option }

  type Model =
    | Concrete of Model'
    | Random of Model'
    | FromPicker of Model'

  
  let defaultImage =
    Concrete { Name = "Parrot"
               Source = Some (localImage "${entryDir}/../parrot.png") }

  let random () =
    let id = JS.Math.round (JS.Math.random () * 992.)
    let timestamp = JS.Date.now ()
    let uri = sprintf "https://picsum.photos/%f?image=%f&t=%f" Constants.imageHeight id timestamp
    Random { Name = "Random"
             Source = Some (remoteImage [ Uri uri ]) }

  let fromPicker source =
    FromPicker { Name = "Pick image"
                 Source = source }

  let availableImages =
    [| defaultImage
       Concrete { Name = "React logo"
                  Source = Some (remoteImage [ Uri "https://tinyurl.com/y8xs3ehd" ]) }
       Concrete { Name = "Triangle"
                  Source = Some (remoteImage [ Uri "https://tinyurl.com/ycedtewy" ]) }
       random ()
       fromPicker None |]

  let equals first second =
    function
    | (Random _), (Random _) -> true
    | (FromPicker _), (FromPicker _) -> true
    | _ -> first = second
  
  let source =
    function
    | Concrete image
    | Random image
    | FromPicker image -> image.Source

  let name =
    function
    | Concrete image
    | Random image
    | FromPicker image -> image.Name
