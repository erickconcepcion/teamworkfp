namespace Utils
open System
module TableParser =
    let DrawTableStruct (rows: List<String[]>)=
        let replicateStr str count = String.replicate count str
        let getRowSplitter arrValues =
            let getHeaderSpliter lengths = 
                let sum3 i = i + 3
                let minus m n = n-m
                lengths |> List.sumBy sum3 |> minus 1 |> replicateStr "-"
            let getMaxStringLength r = 
                r |> Array.map String.length|> Array.max
            arrValues |> List.map getMaxStringLength |> getHeaderSpliter
        let fillStr fill str=
            let minusNatural num1 num2 =
                let res = num1-num2
                if res >=0 then res else 0
            str |> String.length |> minusNatural fill |> replicateStr str
        let drawRowTableStruct row =
            let addPipes s = sprintf " | %s" s
            row |> Array.map addPipes |> Array.reduce (+)
        let addSpliter spliter (strRows: List<string>) =
            let header = [strRows.Head; spliter]
            List.append header strRows.Tail    
        let spliter = getRowSplitter rows
        let concatLines acc el = el |> sprintf "%s\n%s" acc
        rows |> List.map drawRowTableStruct |> addSpliter spliter
        |> List.reduce concatLines
    

    