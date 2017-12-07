namespace AoC.FSharp

module Day05 =
    let solve (x: seq<int>) = 
        let ary = Seq.toArray x
        let max = ary.Length
        let mutable pos = 0
        let mutable counter = 0

        while pos >= 0 && pos < max do
            let jump = ary.[pos]
            Array.set ary pos (jump + 1)
            pos <- pos + jump
            counter <- counter + 1

        counter

    let solve2 (x: seq<int>) = 
        let ary = Seq.toArray x
        let max = ary.Length
        let mutable pos = 0
        let mutable counter = 0

        while pos >= 0 && pos < max do
            let jump = ary.[pos]
            Array.set ary pos (if jump >=3 then jump - 1 else jump + 1)
            pos <- pos + jump
            counter <- counter + 1

        counter