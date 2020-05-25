exception CountingException of string * int

try
    raise (CountingException("number", 1))
with
    | CountingException(msg,num) -> 
        printfn "This is number %d" num