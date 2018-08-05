namespace MatrixFilterConstructor

open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Import

module RN = Fable.Helpers.ReactNative

module Spacer =

  let private containerStyle =
    FastMemoize.memoize (fun height -> ViewProperties.Style [ Height (dip height) ])      

  let view  =
    RN.view [ containerStyle 5. ] []
