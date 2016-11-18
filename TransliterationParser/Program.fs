open FSharp.Data
open System.Text.RegularExpressions

type InputMethod = XmlProvider <"transliteration.xml", Global = true>

[<EntryPoint>]
let main argv = 
    let content = InputMethod.GetSample()
    let mutable text = ""

    for ch in argv.[0] do
        text <- text + ch.ToString()
        let input = content.Patterns |> Seq.where(fun a -> Regex.IsMatch(text, a.Input.Value)) |> Seq.head
        text <- Regex.Replace(text, input.Input.Value, input.Replacement.Value)
    
    printfn "%s - %s" argv.[0] text
    0