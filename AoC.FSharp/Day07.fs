namespace AoC.FSharp

module Day07 =
    open System

    type Node = { 
        Name: string; 
        Weight: int;
        Children: array<string>
    }

    let solve (indata: array<string>) = 
        let split1 (row: string) =
            let parts = row.Split([| " -> " |], StringSplitOptions.None)
            let nameAndWeight = parts.[0]
            let childNames = if parts.Length = 2 then parts.[1] else ""
            let children = childNames.Split([| ", " |], StringSplitOptions.None)
            (nameAndWeight, children)

        let split2 (nameAndWeight: string) =
            let parts = nameAndWeight.Split([| " (" |], StringSplitOptions.None)
            let name = parts.[0]
            let weight = parts.[1].Replace(")", "")
            (name, int weight)

        let parseRow row =
            let (nameAndWeight, children) = split1 row
            let (name, weight) = split2 nameAndWeight
            { Name = name; Weight = weight; Children = children }

        let parse (data: array<string>) =
            Array.map (fun row -> parseRow row) data
        
        let findRoot (nodes: array<Node>) =
            let roots = nodes |> Array.filter (fun n -> 
                not (nodes |> Seq.exists (fun n2 -> 
                    Array.contains n.Name n2.Children)))
            if roots.Length > 1 then failwith "multiple roots" else roots.[0]

        let nodes = parse indata
        let root = findRoot nodes

        root.Name