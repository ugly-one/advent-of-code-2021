open Day9

let arrayInput = Array.map (fun i -> {Value = i; IsMinimum = No}) input.Values
let result = calculateLocalMinima arrayInput
result |> List.iter printPoint
let values = List.map (fun p -> p.Value) result
printfn "%d" (List.sum values + List.length values)