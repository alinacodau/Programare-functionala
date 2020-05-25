seq {0..2..10}                      

seq {for i in seq {1..10} -> i*i}       

let board = 
    seq {
        for row in [1..8] do
            for column in [1..8] do
                yield pown (-1) (row + column)
    } 
    |> Seq.map (fun i -> if i = -1 then "x " else "o ")

let prnt i v =
    if i > 0 && i % 8 = 0 then 
        printfn ""
    printf "%s" v

Seq.iteri prnt board
    
