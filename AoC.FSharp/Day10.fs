namespace AoC.FSharp

open System

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
  
    let solve1 length (s: string) =
        let by = Array.map (fun s -> int s) (s.Split(','))
        let rope = [0 .. length]
        let state = { Rope = rope; Pos = 0; Skip = 0 }
        let tangled = knotMany state by
        tangled.Rope.[0] * tangled.Rope.[1]
    
    let adjustInput (s: string) =
        let bytes = Seq.map (fun c -> int c) s
        Seq.append bytes [| 17; 31; 73; 47; 23 |]

    let densify values =
        Seq.reduce (fun i j -> i ^^^ j) values
    
    let toHex (values: seq<int>) =
        let hexes = Seq.map (fun (x: int) -> String.Format("{0:X2}", x).ToLower()) values
        String.concat "" hexes

    let solve2 s =
        let adjusted = adjustInput s
        let rope = [0 .. 255]
        let initialState = { Rope = rope; Pos = 0; Skip = 0 }
        let tangled = Seq.fold (fun state _ -> knotMany state adjusted) initialState { 1 .. 64 }
        let blocks = Seq.map (fun i -> (Seq.take 16 (Seq.skip (i * 16) tangled.Rope))) { 0 .. 15 }
        let denseBlocks = Seq.map densify blocks
        let hexed = toHex denseBlocks
        hexed