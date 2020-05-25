open System

Double.TryParse("3.14159") |> function
    | (true, value) -> printfn "%f" value
    | (false, _) -> printfn "could not parse"
let (yeahOrNeah, value) = Double.TryParse("3.141five9")
