namespace AoC.FSharp

module Day15 =
    let mutate state factor =
        int (((int64 state) * (int64 factor)) % (int64 2147483647))

    let rec mutate2 state factor m =
        let i = int (((int64 state) * (int64 factor)) % (int64 2147483647))
        if i % m = 0 then
            i
        else
            //printfn "Discarding value %A because %A" i m
            mutate2 i factor m

    let rec mutate2a state factor =
        mutate2 state factor 4

    let rec mutate2b state factor =
        mutate2 state factor 8

    let rec genrec mutator state factor n  (s: seq<int>) =
        if n = Seq.length s then
            s
        else
            let newState = mutator state factor
            //printfn "Adding %A to list" newState
            let newSeq = Seq.append s [newState]
            genrec mutator newState factor n newSeq

    let generator state factor n =
        genrec mutate state factor n []
    
    let generator2a state factor n =
        genrec mutate2a state factor n []

    let generator2b state factor n =
        genrec mutate2b state factor n []

    let rec generateAndMatch mutator1 mutator2 state1 state2 factor1 factor2 n i c =
        if n = i then
            c
        else
            let newState1 = mutator1 state1 factor1
            let newState2 = mutator2 state2 factor2
            let chopped1 = newState1 &&& 0xFFFF
            let chopped2 = newState2 &&& 0xFFFF
            let isMatch = chopped1 = chopped2
            //if isMatch then printfn "Match found in step %A (%A)" i chopped1 else ()
            let newc = c + (if isMatch then 1 else 0)
            generateAndMatch mutator1 mutator2 newState1 newState2 factor1 factor2 n (i + 1) newc

    let solve n s1 s2 =
        generateAndMatch mutate mutate s1 s2 16807 48271 n 0 0

    
    let solve2 n s1 s2 =
        generateAndMatch mutate2a mutate2b s1 s2 16807 48271 n 0 0