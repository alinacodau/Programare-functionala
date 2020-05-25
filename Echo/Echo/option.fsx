open System

let firstOdd xs =
    List.tryPick (fun x -> if x % 2 = 1 then Some x else None) xs

//let firstOdd =
//    List.tryPick (fun x -> if x % 2 = 1 then Some x else None)

firstOdd [2;4;6]
firstOdd [2;4;5;6;7]

let print o = 
    match o with
        | Some v -> sprintf "%A" v
        | None -> "nothing"

let toNumberAndSquare o =
    Option.bind (fun s ->
                    let (succeeded,value) = Double.TryParse(s)
                    if succeeded then Some value else None) o
    |> Option.bind (fun n -> n * n |> Some)

Some "5" |> toNumberAndSquare |> print |> Console.WriteLine
Some "foo" |> toNumberAndSquare |> print |> Console.WriteLine

type Option'<'a> = 
    | Some of 'a
    | None



