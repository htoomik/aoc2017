namespace AoC.FSharp

open System

module Day16 =
    let spin i (s: char[]) = 
        let n = Array.length s
        Array.append s.[(n - i) .. (n - 1)] s.[0 .. (n - i - 1)]

    let exchange (i: int) (j: int) (s: char[]) =
        let (si, sj) = (s.[i], s.[j])
        s.[i] <- sj
        s.[j] <- si
        s

    let partner a b (s: char[]) =
        let ia = Array.findIndex ((=) a) s
        let ib = Array.findIndex ((=) b) s
        s.[ia] <- b
        s.[ib] <- a
        s
    
    type Instruction = {
        Command: char;
        Arg1c: char;
        Arg2c: char;
        Arg1i: int;
        Arg2i: int
    }

    let parse (instruction: string) =
        let command = instruction.[0]
        let theRest = instruction.[1..]
        if command = 's' then
            { Command = command; Arg1c = (char 0); Arg2c = (char 0); Arg1i = (int theRest); Arg2i = 0 }
        else
            let parts = theRest.Split('/')
            if command = 'x' then
                { Command = command; Arg1c = (char 0); Arg2c = (char 0); Arg1i = (int parts.[0]); Arg2i = (int parts.[1]) }
            else
                { Command = command; Arg1c = (char parts.[0]); Arg2c = (char parts.[1]); Arg1i = 0; Arg2i = 0 }

    let apply (state: char[]) (instruction: Instruction) =
        if instruction.Command = 's' then
            spin instruction.Arg1i state
        elif instruction.Command = 'x' then
            exchange instruction.Arg1i instruction.Arg2i state
        else
            partner instruction.Arg1c instruction.Arg2c state

    let summarize (s: char[]) =
        String.Concat s

    let solve1 (s: char[]) (raw: string[]) = 
        let instructions = Seq.map parse raw
        Seq.fold apply s instructions
    
    let solve2 (s: char[]) (raw: string[]) n = 
        let instructions = Array.map parse raw
        let s2 = Array.ofSeq s
        printfn "indata: %A" s2
        Array.fold (fun state i ->
            printfn "%A" (summarize state)
            if i % 10000 = 0 then printfn "%A" i else ()
            Array.fold apply state instructions) s2 [|1..n|]
