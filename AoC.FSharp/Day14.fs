namespace AoC.FSharp

open System

module Day14 =
    let toInts s =
        s |> Seq.map (fun c -> int c - int '1' + 1) |> List.ofSeq

    let toBools s =
        Seq.map (fun c -> c = '1') s

    let toBin (inData: string) =
        inData
        |> Seq.map (fun c -> c.ToString())
        |> Seq.map (fun s -> Convert.ToInt16(s, 16))
        |> Seq.map (fun i -> Convert.ToString(i, 2))
        |> Seq.map (fun s -> s.PadLeft(4, '0'))
        |> String.concat ""

    let solve1 key = 
        let hashes = Seq.map (fun i -> Day10.solve2 (key + "-" + i.ToString())) {0..127}
        let binary = Seq.map toBin hashes
        let all = Seq.concat binary 
        let count = Seq.sum (toInts all)
        count
    
    let inBounds (x, y) =
        x >=0 && x <= 127 && y >= 0 && y <= 127

    let rec markRegion (ary: int[,]) z (q: list<(int*int)>) =
        if q.Length > 0 then
            let (x, y) = q.Head
            let neighborCoordsRaw = [ (x, y + 1); (x, y - 1); (x - 1, y); (x + 1, y) ]
            let neighborCoords = List.filter inBounds neighborCoordsRaw
            let neighbors = List.filter (fun (i, j) -> ary.[i, j] = 1) neighborCoords
            Seq.iter (fun (i, j) -> ary.[i, j] <- -1) neighbors
            let newQueue = List.append neighbors q.Tail
            markRegion ary z newQueue
        ()

    let countRegions (ary: int[,]) =
        let mutable i = 0
        for x in [0..127] do
            for y in [0..127] do
                let pixel = ary.[x,y]
                if pixel = 1 then 
                    i <- i + 1
                    markRegion ary i [(x, y)]
        // process each pixel
        // if pixel is 1 and not part of region, start new region
        // create queue
        // add all its neighbours to the queue
        // for each neighbour:
        //     if is 1 then add all its neighbours to the queue
        //     if is 0 then done
        i

    let solve2 key = 
        let hashes = Seq.map (fun i -> Day10.solve2 (key + "-" + i.ToString())) {0..127}
        let binary = Seq.map toBin hashes
        let ints = Seq.map (fun s-> toInts s) binary
        let ary = array2D ints
        countRegions ary
