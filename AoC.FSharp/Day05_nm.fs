﻿namespace AoC.FSharp

module Day05_nm =
    let adjStep1 x =
        x + 1
    
    let adjStep2 x =
        if x >= 3 then x - 1 else x + 1

    let rec doit (state: int[]) pos counter adjuster =
        //printfn "counter %A, position %A, state %A" counter pos state
        let jump = state.[pos]
        let newCounter = counter + 1
        let newPos = pos + jump

        if (newPos < 0 || newPos >= Seq.length state) then
            newCounter
        else
            state.[pos] <- adjuster state.[pos]
            doit state newPos newCounter adjuster

    let solve (x: int list) = 
        doit (Array.ofList x) 0 0 adjStep1

    let solve2 (x: int list) = 
        doit (Array.ofList x) 0 0 adjStep2