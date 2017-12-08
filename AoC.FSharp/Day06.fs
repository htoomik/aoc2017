namespace AoC.FSharp

open System

module Day06 =
    let solve (indata: seq<int>) = 
        let summarize (values: int[]) =
            String.Concat (Array.map (fun x -> string x ) values)

        let redistribute (state: int[]) =
            let max = Seq.max state
            let i = Seq.findIndex (fun x -> x = max) state
            Array.set state i 0
            for j = 1 to max do
                let index = (i + j) % state.Length
                Array.set state index (state.[index] + 1)
            ()
        
        let state = Seq.toArray indata
        let mutable states : string List = [];
        let mutable summary = summarize state
        let mutable counter = 0

        while not (List.exists (fun x -> x = summary) states) do
            states <- summary :: states
            counter <- counter + 1
            redistribute state
            summary <- summarize state
            ()
        
        //printfn "%A" states

        let cycle = List.findIndex (fun x -> x = summary) states
        (counter, cycle + 1)

