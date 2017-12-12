namespace AoC.FSharp

module Day10 =
    type State = {
        Rope: int list
        Pos: int
        Skip: int
    }

    let isInRange x fromI toI =
        if fromI <= toI then
            x >= fromI && x <= toI
        else
            x >= fromI || x <= toI

    let twist (rope: int list) fromI toI =
        let adjustedFromI = fromI % rope.Length
        let adjustedToI = toI % rope.Length

        //printfn "twisting elements %A to %A" adjustedFromI adjustedToI

        List.mapi (fun i x -> 
            if isInRange i adjustedFromI adjustedToI then 
                let x = (adjustedToI - i + adjustedFromI + rope.Length) % rope.Length
                //printfn "swapping element %A with %A" i x
                rope.[x] 
            else 
                x) 
                rope

    let knot (state: State) by =
        //printfn "state %A" (List.fold (fun s i -> s + i.ToString() + ",") "" state.Rope)
        //printfn "twist %A elements starting at %A" by state.Pos

        let twisted = if by = 0 then state.Rope else twist state.Rope state.Pos (state.Pos + by - 1)
        { Rope = twisted; Pos = state.Pos + by + state.Skip; Skip = state.Skip + 1 }

    let knotMany state by =
        Seq.fold knot state by

    let tangle length by =
        let rope = [0 .. length]
        let state = { Rope = rope; Pos = 0; Skip = 0 }
        knotMany state by

    let solve length (s: string) =
        let by = Array.map (fun s -> int s) (s.Split(','))
        //printfn "by %A" by
        let tangled = tangle length by
        printfn "%A" tangled
        tangled.Rope.[0] * tangled.Rope.[1]
    
