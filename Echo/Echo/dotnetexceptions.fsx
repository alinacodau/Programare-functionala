try
    raise (new System.Exception("General error"))
    //1 / 0
with
    | :? System.DivideByZeroException as ex -> 
        printfn "Don't do that %s" ex.Message 
        0
    | :? System.Exception as ex when ex.Message = "General error" ->
        printfn "Some other error %s" ex.Message
        0
