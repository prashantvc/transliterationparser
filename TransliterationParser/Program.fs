open FSharp.Data
open System.Text.RegularExpressions


type InputMethod = XmlProvider <"transliteration.xml", Global = true>

[<EntryPoint>]
let main argv = 
    let content = InputMethod.GetSample()
    let mutable text = ""

    printfn "%s - %s" argv.[0] text
    0