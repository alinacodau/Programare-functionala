#r @"packages/FParsec.1.0.1\lib\net40-client\FParsecCS.dll"
#r @"packages/FParsec.1.0.1\lib\net40-client\FParsec.dll"

open FParsec

let test p str =
    match run p str with
    | Success(result, _, _)   -> printfn "Success: %A" result
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg

type MeasureFunction = Half | Quarter | Eighth | Sixteenth | Thirtyseconth
type Length = { fraction: MeasureFunction; extended: bool }
type Note = A | ASharp | B | C | CSharp | D | DSharp | E | F | FSharp | G | GSharp
type Octave = One | Two | Three
type Sound = Rest | Tone of note: Note * octave: Octave
type Token = { length: Length; sound: Sound }

let aspiration = "32.#d3"

let pmeasurefraction = 
    (stringReturn "2" Half)
    <|> (stringReturn "4" Quarter)
    <|> (stringReturn "8" Eighth)
    <|> (stringReturn "16" Sixteenth)
    <|> (stringReturn "32" Thirtyseconth)

let pextendedparser = (stringReturn "." true) <|> (stringReturn "" false)

let plength = 
    pipe2 
        pmeasurefraction
        pextendedparser
        (fun t e -> {fraction = t; extended = e})

let pnotsharpablenote = anyOf "be" |>> (function 
                            | 'b' -> B
                            | 'e' -> E
                            | unknown -> sprintf "Unknown note %c" unknown |> failwith)

let psharp = (stringReturn "#" true) <|> (stringReturn "" false)

let psharpnote = pipe2 
                    psharp 
                    (anyOf "acdfg") 
                    (fun isSharp note -> 
                        match (isSharp, note) with
                        | (false, 'a') -> A
                        | (true, 'a') -> ASharp                    
                        | (false, 'c') -> C
                        | (true, 'c') -> CSharp
                        | (false, 'd') -> D
                        | (true, 'd') -> DSharp
                        | (false, 'f') -> F
                        | (true, 'f') -> FSharp
                        | (false, 'g') -> G
                        | (true, 'g') -> GSharp
                        | (_,unknown) -> sprintf "Unknown note %c" unknown |> failwith)

let pnote = pnotsharpablenote <|> psharpnote

let poctave = anyOf "123" |>> (function 
                | '1' -> One 
                | '2' -> Two
                | '3' -> Three
                | unknown -> sprintf "Unknown octave %c" unknown |> failwith)

let ptone = pipe2 pnote poctave (fun n o -> Tone(note = n, octave = o))

let prest = stringReturn "-" Rest

let ptoken = pipe2 plength (prest <|> ptone) (fun l  t -> {length = l; sound = t })

let pscore = sepBy ptoken (pstring " ")

test pscore "2- 16a1 16- 16a1 16- 8a1 16- 4a2 16g2 16- 2g2 16- 4- 8- 16g2 16- 16g2 16- 16g2 8g2 16- 4c2 16#a1 16- 4a2 8g2 4f2 4g2 8d2 8f2 16- 16f2 16- 16c2 8c2 16- 4a2 8g2 16f2 16- 8f2 16- 16c2 16- 4g2 4f2"

test ptoken aspiration

test ptone "#d3"

test poctave "2"
 
test pnote "#b"
 
test plength "asfsad"

test pmeasurefraction aspiration
