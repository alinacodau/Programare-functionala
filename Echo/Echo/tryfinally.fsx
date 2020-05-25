try
    try
        failwith "An error message"
    with
        | Failure msg -> printfn "Failed with %s" msg
finally
    printfn "This always evaluates"

try
    try
        failwith "An error message"
    finally
        printfn "This always evaluates"
with
    | Failure msg -> printfn "Failed with %s" msg