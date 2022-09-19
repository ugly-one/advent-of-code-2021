module Day1

let calculate input =
    let folder item (result, maybeNextItem) = 
        match maybeNextItem with 
            | Some(nextItem) -> if nextItem > item then (result + 1, Some(item)) else (result, Some(item))
            | None -> (result, Some(item))

    let (a, _) = Array.foldBack folder input (0, None)
    a