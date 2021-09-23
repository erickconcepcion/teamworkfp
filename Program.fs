// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Utils

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let list: List<String[]> = [
        [|"Name"; "Value"|]
        [|"Erick"; "Hue"|]
        [|"Cama"; "Objeto"|]
        [|"Esto"; "Aquello"|]
        [|"Mar"; "Icon"|]
    ]
    let tab = TableParser.DrawTableStruct list
    printfn "%s" tab
    let key = Console.ReadKey()
    0 // return an integer exit code