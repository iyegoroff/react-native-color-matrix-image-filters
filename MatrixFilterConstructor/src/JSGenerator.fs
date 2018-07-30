namespace MatrixFilterConstructor

open System

module JSGenerator =

  let private imports = "__IMPORTS__"
  let private matrices = "__MATRICES__"
  let private props = "__PROPS__"

  let private (|Template|Line|Imports|Props|Matrices|) (input: string) =
    if input.IndexOf "\n" <> -1 then
      Template (input.Split ([|"\n"|], StringSplitOptions.None))

    elif input.IndexOf imports <> -1 then
      Imports (input.Replace (imports, ""))

    elif input.IndexOf props <> -1 then
      Props (input.Replace (props, ""))

    elif input.IndexOf matrices <> -1 then
      Matrices (input.Replace (matrices, ""))

    else
      Line input

  let private importName filter =
    (CombinedFilterControl.name filter).ToCharArray ()
    |> Array.mapi (fun i v -> if i = 0 then Char.ToLower v else v)
    |> String.Concat

  let run (selectedFilters: (CombinedFilterControl.Model * float option) list): string =
    let selectedFilters =
      selectedFilters
      |> List.mapFold
           (fun (map: Map<string, int>) (filter, value) -> 
              let name = (importName filter)
              let id = 1 + defaultArg (map.TryFind name) 0
              (name, value, id), Map.add name id map)
           Map.empty
      |> fst
      |> List.map (fun (name, value, id) -> (name, value, if id = 1 then "" else (string id)))

    let rec generate =
      function
      | Template lines ->
        lines
        |> Array.map generate
        |> String.concat "\n"

      | Imports padding ->
        selectedFilters
        |> List.map (fun (name, _, _) -> name)
        |> List.distinct
        |> String.concat (sprintf ",\n%s" padding)
        |> sprintf "%s%s" padding

      | Props padding ->
        selectedFilters
        |> List.filter (fun (_, value, _) -> value.IsSome)
        |> List.map (fun (name, value, id) ->
             (sprintf "%s%s: %sValue%s = %f," name id name id (defaultArg value 0.)))
        |> String.concat (sprintf "\n%s" padding)
        |> sprintf "%s%s" padding

      | Matrices padding ->
        selectedFilters
        |> List.map
             (fun (name, value, id) ->
                match value with
                | Some _ -> (sprintf "%s(%sValue%s)" name name id)
                | None -> (sprintf "%s()" name))
        |> String.concat (sprintf ",\n%s" padding)
        |> sprintf "%s%s" padding

      | Line input -> input

    generate JSTemplate.template
