namespace Utils
open System
module TableParser =
    let StringLength s =
        String.length s
    let GetMaxStringLength r =
        r |> Array.map StringLength |> Array.max
    let GetMaxColumnsWidth arrValues =
        arrValues
        |> Array.map GetMaxStringLength
    let DrawSpliter count =
        String.replicate count "-"
    let GetHeaderSpliter lens = 
        lens |> Array.sumBy (fun i -> i + 3) |> (-)1 |> DrawSpliter
    let AddPipes s =
        sprintf " | %s" s
    let FillStr fill=
        (fun s -> String.replicate (fill-(String.length s)) s)
    let DrawTableStruct rows =
        rows |> Array.map AddPipes |> Array.reduce (+)

    