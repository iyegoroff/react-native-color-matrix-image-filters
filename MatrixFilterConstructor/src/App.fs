namespace FilterConstructor

open Elmish
open Elmish.ReactNative
open Elmish.HMR


module App =

  Program.mkProgram Main.init Main.update Main.view
  |> Program.withConsoleTrace
  |> Program.withHMR
  |> Program.withReactNative "MatrixFilterConstructor"
  |> Program.run
