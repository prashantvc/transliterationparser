namespace TransliterationLib

open FSharp.Data
open System.Text.RegularExpressions


type InputMethod = XmlProvider <"transliteration.xml", EmbeddedResource  ="TransliterationLib, transliteration.xml",  Global = true>

type Transliteration() =

    member this.Translate (value:string) =
        try
            let content = InputMethod.GetSample()
            let mutable text = ""

            for ch in value do
                text <- text + ch.ToString()
                let input = content.Patterns |> Seq.where(fun a -> Regex.IsMatch(text, a.Input.Value)) |> Seq.head
                text <- Regex.Replace(text, input.Input.Value, input.Replacement.Value)

            text
        with 
        | :? System.Exception as ex -> 
            ex.ToString()