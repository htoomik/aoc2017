namespace AoC.FSharp

open System

module Day01 =
    let solve (inData:string) = 
        let toInts s =
            s |> Seq.map (fun c -> int c - int '1' + 1) |> List.ofSeq
        let is = toInts inData
        let isShifted = is.Tail @ [is.Head]

        printfn "is: %A" is
        printfn "isShifted: %A" isShifted

        let sumMatches list1 list2 =
            let matches = List.map2 (fun i1 i2 -> 
                if (i1 = i2) then i1 else 0)
            let ms = matches list1 list2
            printfn "ms: %A" ms
            List.sum ms
        
        sumMatches is isShifted