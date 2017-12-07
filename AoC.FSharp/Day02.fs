namespace AoC.FSharp

module Day02 =
    let solve (indata: int list list) = 
        let diffs = indata |> List.map(fun row ->
            let min = List.min(row)
            let max = List.max(row)
            max - min
        )
        List.sum diffs

    let solve2 (indata: int list list) = 
        let divisible x y =
            x <> y && x % y = 0
        
        let findPair (ints: int list) = 
            ints |> List.pick(fun i ->
                let j = ints |> List.tryFind(fun j -> divisible i j)
                match j with
                | Some j -> Some (i, j)
                | None -> None
            )

        let ratios = indata |> List.map(fun row ->
            let (a, b) = findPair row
            a / b
        )

        List.sum ratios