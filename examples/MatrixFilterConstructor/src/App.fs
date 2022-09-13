namespace MatrixFilterConstructor

open Elmish
open Elmish.ReactNative
open Elmish.HMR


module App =

  Program.mkProgram Main.init Main.update Main.pureView
  |> Program.withSubscription Main.subscribe
  |> Program.withHMR
  |> Program.withReactNative "MatrixFilterConstructor"
  |> Program.run
