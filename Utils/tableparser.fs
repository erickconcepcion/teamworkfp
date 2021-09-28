namespace Utils
open System
module TableParser =
    let DrawTableStruct (rows: List<String[]>)=
        let replicateStr str count = String.replicate count str
        
        let getMaxStringLength r = 
            r |> Array.map String.length
        
        let getMaxColumnWiths arrValues = 
            let colWidthFolder (colMax: int[]) (newArr: int[]) =
                let moreOrEqual n1 n2 = if n1 >= n2 then n1 else n2
                [| for i in 0 .. (Array.length colMax) - 1 -> moreOrEqual colMax.[i] newArr.[i] |]
            let getMaxColWidths (lengths: List<int[]>) =
                let length = Array.length lengths.Head
                let lengthZeros: int array = Array.zeroCreate length
                List.fold colWidthFolder lengthZeros lengths
            arrValues |> List.map getMaxStringLength |> getMaxColWidths
        
        let getRowSplitter arrValues =
            let getHeaderSpliter lengths = 
                lengths |> Array.sumBy (fun i -> i + 3) |> replicateStr "-"
            arrValues |> getMaxColumnWiths |> getHeaderSpliter

        let colWidths = getMaxColumnWiths rows
        let drawRowTableStruct row =
            let addPipes s = sprintf " | %s" s
            let expandCell  i (el: string) = el.PadRight(colWidths.[i])
            row |> Array.mapi expandCell |> Array.map addPipes |> Array.reduce (+)

        let addSpliter spliter (strRows: List<string>) =
            let header = [strRows.Head; spliter]
            List.append header strRows.Tail

        let spliter = getRowSplitter rows
        let concatLines acc el = el |> sprintf "%s\n%s" acc
        rows |> List.map drawRowTableStruct
        |> addSpliter spliter
        |> List.reduce concatLines
    
    let DrawStringTable colHeader (valueSelector:('b -> 'c)[]) values =
        let rowCreator selectors value = Array.map (fun el -> $"{(el value)}") selectors
        let writeTable (values: List<string[]>) = 
            let (colLen, dataLen) = (Array.length values.Head, Array.length values.Tail.Head)
            if colLen = dataLen then DrawTableStruct values 
            else $"There are {colLen} definitions and the table needs {dataLen} according to the data"
        values |> List.map (fun v -> rowCreator valueSelector v)
        |> List.append [colHeader] 
        |> writeTable

        
        
    

    