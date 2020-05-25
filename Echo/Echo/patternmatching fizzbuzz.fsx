let fizzbuzzer i =
    match i with
        | _ when i % 3 = 0 && i % 5 = 0 -> "fizzbuzz"
        | _ when i % 3 = 0 -> "fizz"
        | _ when i % 5 = 0 -> "buzz"
        | _ -> string i

[1..100] |> List.map fizzbuzzer