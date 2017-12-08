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

        let findChildren (node: Node) (nodes: seq<Node>) =
            nodes |> Seq.filter (fun n -> node.Children |> Seq.contains n.Name)
        
        let rec weigh (node: Node) (nodes: seq<Node>) =
            let children = findChildren node nodes
            let childWeights = children |> Seq.map (fun c -> weigh c nodes)
            let fullWeight = node.Weight + (childWeights |> Seq.map (fun (n, w) -> w) |> Seq.sum)
            (node, fullWeight)

        let rec findImbalance (nodes: seq<Node>) (allNodes: seq<Node>) =
            let weights = nodes |> Seq.map (fun c -> weigh c allNodes)
            let weightsGrouped = weights |> Seq.groupBy (fun (n, w) -> w)
        
            let isInBalance = Seq.length weightsGrouped = 1
            if isInBalance then
                None
            else
                let (deviantWeight, deviantNodes) = weightsGrouped |> Seq.find (fun (k, v) -> Seq.length v = 1)
                let (normalWeight, _ ) = weightsGrouped |> Seq.find (fun (k, v) -> Seq.length v > 1)
                let (deviantNode, w) = Seq.head deviantNodes
                let itsChildren = findChildren deviantNode allNodes
                if Seq.length itsChildren = 0 then
                    Some normalWeight
                else
                    let imbalancedChild = findImbalance itsChildren allNodes
                    match imbalancedChild with 
                    | Some _ -> imbalancedChild
                    | None -> Some (deviantNode.Weight + normalWeight - deviantWeight)
        
        let childrenOfRoot = findChildren root nodes
        let imbalance = findImbalance childrenOfRoot nodes

        (root.Name, Option.get imbalance)