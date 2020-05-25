namespace Web.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax
open System.Net.Mime

type HomeController() =
    inherit Controller()

    member this.Index () = this.View()

    [<HttpPost>]
    member this.Produce(score:string) =
        match Assembler.assembleToPackedStream score with
            | Choice2Of2 ms -> 
                this.Response.AppendHeader(
                    "Content-Disposition",
                    (ContentDisposition(FileName = "ringring.wav", Inline=false)).ToString())
                ms.Position <- 0L
                this.File(ms, "audio/x-wav")
            | Choice1Of2 err -> failwith err

   


