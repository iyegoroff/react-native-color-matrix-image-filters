namespace MatrixFilterConstructor

open System

module JSGenerator =

  let private imports = "__IMPORTS__"
  let private matrices = "__MATRICES__"
  let private props = "__PROPS__"
  let private initState = "__INITSTATE__"
  let private animate = "__ANIMATE__"
  let private state = "__STATE__"

  let private (|Line|Imports|Props|Matrices|InitState|Animate|State|) (input: string) =
    if input.IndexOf imports <> -1 then
      Imports (input.Replace (imports, ""))

    elif input.IndexOf props <> -1 then
      Props (input.Replace (props, ""))

    elif input.IndexOf matrices <> -1 then
      Matrices (input.Replace (matrices, ""))

    elif input.IndexOf initState <> -1 then
      InitState (input.Replace (initState, ""))

    elif input.IndexOf animate <> -1 then
      Animate (input.Replace (animate, ""))

    elif input.IndexOf state <> -1 then
      State (input.Replace (state, ""))

    else
      Line input

  let private importName filter =
    (CombinedFilter.name filter).Replace("Animated", "").Replace("RGBA", "rgba").ToCharArray ()
    |> Array.mapi (fun i v -> if i = 0 then Char.ToLower v else v)
    |> String.Concat

  let private inputValue (input: CombinedFilterInput.Model) =
    match input with
    | CombinedFilterInput.Range value -> (sprintf "%.2f" value.Value)
    | CombinedFilterInput.Animated value -> (sprintf "%.2f" value.Animated.Value)
    | CombinedFilterInput.Color value -> (sprintf "'%s'" value.Value)

  let private inputMin (input: CombinedFilterInput.Model) =
    match input with
    | CombinedFilterInput.Animated value -> (sprintf "%.2f" value.Animated.Min)
    | _ -> ""

  let private inputMax (input: CombinedFilterInput.Model) =
    match input with
    | CombinedFilterInput.Animated value -> (sprintf "%.2f" value.Animated.Max)
    | _ -> ""

  let private stepValue (input: CombinedFilterInput.Model) =
    match input with
    | CombinedFilterInput.Animated value -> (sprintf "%.2f" value.Step.Value)
    | _ -> "0"

  let private hasAnimated (_, input: CombinedFilterInput.Model) =
    match input with
    | CombinedFilterInput.Animated _ -> true
    | _ -> false

  let run (selectedFilters: (CombinedFilter.Model * Filter.Model) list): string =
    let selectedFilters =
      selectedFilters
      |> List.mapFold
           (fun (map: Map<string, int>) (filter, value) -> 
              let name = (importName filter)
              let id = 1 + defaultArg (map.TryFind name) 0
              (name, value, id), Map.add name id map)
           Map.empty
      |> fst
      |> List.map (fun (name, values, id) -> (name, values, if id = 1 then "" else (string id)))

    let enumerateFilters filterAnimated map padding =
      selectedFilters
      |> List.filter
           (fun (_, values, _) ->
              values.Length > 0 && filterAnimated (List.exists hasAnimated values))
      |> List.collect (fun (name, values, id) -> List.map (fun value -> name, value, id) values)
      |> List.map map
      |> String.concat (sprintf "\n%s" padding)
      |> sprintf "%s%s" padding

    let rec generate =
      function
      | Imports padding ->
        selectedFilters
        |> List.map (fun (name, _, _) -> name)
        |> List.distinct
        |> String.concat (sprintf ",\n%s" padding)
        |> sprintf "%s%s" padding

      | InitState padding ->
        enumerateFilters
          id
          (fun (name, (inputName, _), id) ->
             match inputName with
             | Filter.Amount ->
               sprintf "%s%s: props.%s%s || 0,\n%s%sDirection%s: 1," name id name id padding name id
             | _ -> "")
          padding

      | Animate padding ->
        let declarations =
          enumerateFilters
            id
            (fun (name, (inputName, input), id) ->
               match inputName with
               | Filter.Amount ->
                 let nameId = sprintf "%s%s" name id
                 let min = sprintf "(props.%sMin%s || %s)" name id (inputMin input)
                 let max = sprintf "(props.%sMax%s || %s)" name id (inputMax input)
                 let dir = sprintf "%sDirection%s" name id
                 let step = sprintf "(props.%sStep%s || %s)" name id (stepValue input)

                 let firstLine =
                   sprintf
                     "const %s = Math.max(%s, Math.min(%s, state.%s + state.%s * %s));"
                     nameId min max nameId dir step

                 let secondLine =
                   sprintf
                     "const %s = %s === %s ? 1 : %s === %s ? -1 : state.%s;"
                     dir nameId min nameId max dir

                 sprintf "%s\n%s%s" firstLine padding secondLine
               | _ -> "")
            padding

        let state =
          enumerateFilters
            id
            (fun (name, (inputName, _), id) ->
               match inputName with
               | Filter.Amount -> sprintf "%s%s,\n%s  %sDirection%s," name id padding name id
               | _ -> "")
            (sprintf "  %s" padding)
        
        sprintf "%s\n\n%sreturn {\n%s\n%s};" declarations padding state padding

      | State padding ->
        enumerateFilters
          id
          (fun (name, (inputName, _), id) ->
             match inputName with
             | Filter.Amount -> sprintf "%s%s: %sValue%s," name id name id
             | _ -> "")
          padding

      | Props padding ->
        enumerateFilters
          not
          (fun (name, (inputName, input), id) ->
             match inputName with
             | Filter.Amount -> sprintf "%s%s: %sValue%s = %s," name id name id (inputValue input)
             | _ -> sprintf "%s%A%s = %s" name inputName id (inputValue input))
          padding

      | Matrices padding ->
        selectedFilters
        |> List.map
             (fun (name, values, id) ->
                if values.Length > 0 then
                  values
                  |> List.map (fun (inputName, _) -> sprintf "%s%A%s" name inputName id)
                  |> (fun valueNames -> String.Join (", ", valueNames))
                  |> sprintf "%s(%s)" name
                else
                  sprintf "%s()" name)
        |> String.concat (sprintf ",\n%s" padding)
        |> sprintf "%s%s" padding

      | Line input -> input

    selectedFilters
    |> List.collect (fun (_, inputs, _) -> inputs)
    |> List.fold
         (fun template input -> if hasAnimated input then JSTemplateAnimated.template else template)
         JSTemplate.template
    |> (fun template -> template.Split ([|"\n"|], StringSplitOptions.None))
    |> Array.map generate
    |> String.concat "\n"
