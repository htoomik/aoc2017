namespace AoC.FSharp

open System

module Day13 =
    type Layer = {
        Depth: int;
        Range: int;
        Score: int
    }

    let parse (s: string) =
        let parts = s.Split(':')
        let depth = int(parts.[0].Trim())
        let range = int(parts.[1].Trim())
        let score = depth * range
        { Depth = depth; Range = range; Score = score }
    
    let tryFindLayer i layers =
        Seq.tryFind (fun layer -> layer.Depth = i) layers

    let test t delay (layers: List<Option<Layer>>) =
        let layer = layers.[t]
        match layer with
        | None -> 0
        | Some l -> 
            if (t + delay) % ((l.Range - 1) * 2) = 0 then
                1
            else
                0

    let cross delay maxDepth layers =
        Seq.map (fun i -> test i delay layers) {0..maxDepth}
    
    let score (catches: seq<int>) (layers: List<Option<Layer>>) =
        let scores = Seq.mapi (fun i c -> 
            if c = 0 then
                0
            else
                let layer = layers.[i]
                match layer with
                | None -> 0
                | Some l -> l.Score) catches
        //let scoreSummary = String.concat "," (Seq.map (fun i -> i.ToString()) scores)
        //printfn "scores: %A" scoreSummary
        scores


    let solve1 (indata: seq<string>) = 
        let layers = Seq.map parse indata
        let maxDepth = Seq.max (Seq.map (fun l -> l.Depth) layers)
        let allLayers = List.map (fun i -> tryFindLayer i layers) [0..maxDepth]
        let catches = cross 0 maxDepth allLayers
        let scores = score catches allLayers
        Seq.sum scores

    let rec solveRec i maxDepth layers =
        let catches = cross i maxDepth layers
        let result = Seq.max catches
        if i % 1000000 = 0 then (printfn "%A" i) else ()
        if result = 0 then
            i
        else 
            solveRec (i + 1) maxDepth layers

    let solve2 (indata: seq<string>) =
        let layers = Seq.map parse indata
        let maxDepth = Seq.max (Seq.map (fun l -> l.Depth) layers)
        let allLayers = List.map (fun i -> tryFindLayer i layers) [0..maxDepth]
        solveRec 0 maxDepth allLayers