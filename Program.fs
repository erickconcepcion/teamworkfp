// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Utils

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom
type NameDsc = {Name: string; Dsc: string}
[<EntryPoint>]
let main argv =
    
    let list: List<NameDsc> = [
        {Name ="Erick"; Dsc="Hue" }
        {Name ="Cama"; Dsc="Objeto"}
        {Name ="Esto"; Dsc="Aquello"}
        {Name ="Mar"; Dsc="Icon"}
    ]
    let tab = TableParser.DrawStringTable [|"Name"; "Value"; "Concat Name+Value"|] [| 
        (fun v -> v.Name)
        (fun v -> v.Dsc)
        (fun v -> $"{v.Name} {v.Dsc}") |] list
    printfn "%s" tab
    let key = Console.ReadKey()
    0 // return an integer exit code