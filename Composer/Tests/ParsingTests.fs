module ParsingTests

open NUnit.Framework
open Parsing

[<TestFixture>]
type ``when parsing a score`` ()=

    [<Test>]
    member this.``it should parse a simple score`` ()=
        let score = "32.#d3 16-"
        let result = parse score
        let assertFirstToken token =
            Assert.AreEqual({fraction = Thirtyseconth; extended = true}, token.length)
            Assert.AreEqual(Tone (DSharp,Three), token.sound)
        let assertSecondToken token =
            Assert.AreEqual({fraction = Sixteenth; extended = false}, token.length)
            Assert.AreEqual(Rest, token.sound)

        match result with
            | Choice1Of2 errorMsg -> Assert.Fail(errorMsg)
            | Choice2Of2 tokens ->
                Assert.AreEqual(2, List.length tokens)
                printfn "%A" tokens
                List.head tokens |> assertFirstToken
                List.nth tokens 1 |> assertSecondToken
                ()
                    

