open System

//let (isSuccess, value) = Double.TryParse("3.14159")
let (isSuccess, value) = Double.TryParse("3.141five9")

Double.TryParse("3.141five9") |> (fun result ->
    match result with
        | (true, value) -> printfn "%f" value
        | (false, _) -> printfn "could not parse")

Double.TryParse("3.14159") |> function
    | (true, value) -> printfn "%f" value
    | (false, _) -> printfn "could not parse"