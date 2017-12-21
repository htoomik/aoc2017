namespace AoC.FSharp

open System

module Day21 =
    type Rule = {
        Left: char list list
        Right: char list list
        Dim: int
    }

    let parse2 (rows: string[]) =
        rows 
            |> Array.map (fun s -> List.ofSeq(Seq.map (fun c -> c) s))
            |> List.ofArray

    let parse (rule: string) =
        let parts = rule.Split([|" => "|], StringSplitOptions.None)
        let left = parts.[0].Split('/')
        let right = parts.[1].Split('/')
        let leftList = parse2 left
        let rightList = parse2 right
        { Left = leftList; Right = rightList; Dim = Array.length left }
    
    let rotate rule =
        if rule.Dim = 2 then
            let newLeft = [
                [ rule.Left.[1].[0]; rule.Left.[0].[0] ];
                [ rule.Left.[1].[1]; rule.Left.[0].[1] ]
            ]
            { Left = newLeft; Right = rule.Right; Dim = rule.Dim }
        else
            let newLeft = [
                [ rule.Left.[2].[0]; rule.Left.[1].[0]; rule.Left.[0].[0] ];
                [ rule.Left.[2].[1]; rule.Left.[1].[1]; rule.Left.[0].[1] ];
                [ rule.Left.[2].[2]; rule.Left.[1].[2]; rule.Left.[0].[2] ]
            ]
            { Left = newLeft; Right = rule.Right; Dim = rule.Dim }

    let flip (rule: Rule) =
        { Left = List.rev rule.Left; Right = rule.Right; Dim = rule.Dim }

    let mutateOne rule =
        let rotated1 = rotate rule
        let rotated2 = rotate rotated1
        let rotated3 = rotate rotated2
        let rotated = [rule; rotated1; rotated2; rotated3]
        let flipped = List.map (fun rule -> flip rule) rotated
        List.append rotated flipped

    let mutate rules =
        List.concat (List.map (fun rule -> mutateOne rule) rules)

    let findRule (rules: Rule list) chunk =
        List.find (fun r -> r.Left = chunk) rules

    let transform rules (chunk: char list list) =
        let rule = findRule rules chunk
        rule.Right

    let applyRules rules2 rules3 (state: char list list) =
        let dim = if (List.length state) % 2 = 0 then 2 else 3
        let chunkCount = (List.length state) / dim
        let chunks = List.map (fun i -> List.map(fun j -> List.map(fun x -> List.map(fun y -> state.[i * dim + x].[j * dim + y]) [0 .. dim - 1]) [0 .. dim - 1]) [0 .. chunkCount - 1]) [0 .. chunkCount - 1]
        let applicable = if dim = 2 then rules2 else rules3
        let newChunks = List.map (fun c -> List.map(fun d-> transform applicable d) c) chunks
        let newDim = dim + 1
        let n = chunkCount * newDim
        let merged = List.map (fun i -> List.map(fun j -> newChunks.[i / newDim].[j / newDim].[i % newDim].[j % newDim] ) [0..n-1]) [0..n-1]
        merged

    let countHashes (state: char list list) =
        let merged = List.concat state
        List.length (List.filter (fun c -> c = '#') merged)

    let solve rules iterations =
        let parsedRules = List.map parse rules
        let fullRules = mutate parsedRules
        let initialState = parse2 [| ".#."; "..#"; "###" |]
        let rules2 = List.filter (fun rule -> rule.Dim = 2) fullRules
        let rules3 = List.filter (fun rule -> rule.Dim = 3) fullRules
        let finalState = List.fold (fun state i -> 
            printfn "Iteration %A" i
            applyRules rules2 rules3 state) initialState [1..iterations]
        countHashes finalState