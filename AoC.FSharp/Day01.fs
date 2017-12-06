namespace AoC.FSharp

module Day01 =
    let sumMatches list1 list2 =
        let matches = List.map2 (fun i1 i2 -> 
            if (i1 = i2) then i1 else 0)
        let ms = matches list1 list2
        printfn "ms: %A" ms
        List.sum ms

    let toInts s =
        s |> Seq.map (fun c -> int c - int '1' + 1) |> List.ofSeq

    let solve (inData:string) = 
        let is = toInts inData
        let isShifted = is.Tail @ [is.Head]

        //printfn "is: %A" is
        //printfn "isShifted: %A" isShifted
       
        sumMatches is isShifted

    let solve2 (inData:string) = 
        let is = toInts inData

        let n = is.Length / 2
        let half = List.take n is
        let otherHalf = List.skip n is
        let isShifted = otherHalf @ half

        printfn "is: %A" is
        printfn "isShifted: %A" isShifted
        
        sumMatches is isShifted