namespace AoC.FSharp

open System
open System.Collections.Generic

module Day18 =
    type State = {
        registers: Dictionary<char, int64>
        position: int
        frequency: int64
        recovered: int64
    }

    let apply state (instruction: string) =
        let parts = instruction.Trim().Split(' ')
        let reg = parts.[0]
        let x = char parts.[1]
        let part2 = if parts.Length = 3 then parts.[2] else ""
        let y = match part2 with
                | "" -> 0L
                | s -> match System.Int64.TryParse(s) with
                       | (true, int) -> int
                       | _ -> state.registers.[char s]

        let currentX = state.registers.[x]
        let newFrequency = if reg = "snd" then currentX else state.frequency
        let newPosition = if reg = "jgz" && currentX <> 0L then state.position + (int y) else state.position + 1
        let newRecovered = if reg = "rcv" && currentX <> 0L && state.recovered = 0L then state.frequency else 0L
        let newX = match reg with
                   | "set" -> y
                   | "add" -> state.registers.[x] + y
                   | "mul" -> state.registers.[x] * y
                   | "mod" -> state.registers.[x] % y
                   | _ -> state.registers.[x]
        state.registers.[x] <- newX

        let newState = { registers = state.registers; frequency = newFrequency; position = newPosition; recovered = newRecovered }
        printfn "%A" newState
        newState
    
    let rec applyRec state (instructions: string[]) =
        if state.position < 0 || state.position >= instructions.Length then
            printfn "oob %A" state.position
            state
        elif state.recovered > 0L then
            printfn "recovered %A" state.recovered
            state
        else
            let newState = apply state instructions.[state.position]
            applyRec newState instructions

    let solve (instructions: string[]) =
        let registers = new Dictionary<char, int64> (dict (List.map (fun c -> (c, 0L))  ['a'..'z']))
        let starting = { registers = registers; position = 0; frequency = 0L; recovered = 0L }
        let ending = applyRec starting instructions
        ending.frequency

    