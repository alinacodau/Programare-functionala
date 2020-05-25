let distance x y = x - y |> abs

// prefix
distance 5 2

// infix distance
let (|><|) x y = x - y |> abs

5 |><| 2 |><| 10

1 + 3

let add1 = (+) 1

add1 5

(+) 1 3

((+) 1) 3

1 + 2 + 3

36 / 6 / 2

2

((+) ((+) 1 2) 3)
