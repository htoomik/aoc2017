namespace AoC.FSharp

open System
open System.Collections.Generic

module Day23 =
    type State = {
        registers: Dictionary<char, int64>
        position: int
        mulCalls: int
    }

    let apply state (instruction: string) =
        let parts = instruction.Trim().Split(' ')
        let reg = parts.[0]
        let x = match parts.[1] with
                | s -> match System.Int64.TryParse(s) with
                       | (true, int) -> int
                       | (false, _) -> state.registers.[char s]
        let part2 = if parts.Length = 3 then parts.[2] else ""
        let y = match part2 with
                | "" -> 0L
                | s -> match System.Int64.TryParse(s) with
                       | (true, int) -> int
                       | _ -> state.registers.[char s]

        let newPosition = if reg = "jnz" && x <> 0L then state.position + (int y) else state.position + 1
        let newX = match reg with
                   | "set" -> y
                   | "sub" -> x - y
                   | "mul" -> x * y
                   | _ -> x
        let newMulCalls = if reg = "mul" then state.mulCalls + 1 else state.mulCalls
        if reg <> "jnz" then
            state.registers.[char parts.[1]] <- newX

        let newState = { registers = state.registers; position = newPosition; mulCalls = newMulCalls }
        
        printfn "%A" instruction
        state.registers.Keys |> Seq.iter (fun key -> printf "[%A]=%d," key state.registers.[key])
        printfn ""
        
        newState
    
    let rec applyRec state (instructions: string[]) =
        if state.position < 0 || state.position >= instructions.Length then
            printfn "oob %A" state.position
            state
        else
            let newState = apply state instructions.[state.position]
            applyRec newState instructions

    let solve (instructions: string[]) =
        let registers = new Dictionary<char, int64> (dict (List.map (fun c -> (c, 0L))  ['a'..'h']))
        registers.['a'] <- 1L
        let starting = { registers = registers; position = 0; mulCalls = 0 }
        let ending = applyRec starting instructions
        ending.mulCalls

    let solve2 (instructions: string[]) =
        let registers = new Dictionary<char, int64> (dict (List.map (fun c -> (c, 0L))  ['a'..'h']))
        registers.['a'] <- 1L
        registers.['b'] <- 106700L
        registers.['c'] <- 123700L
        registers.['d'] <- 2L
        registers.['e'] <- 106699L
        registers.['f'] <- 0L
        registers.['g'] <- 2L
        registers.['h'] <- 0L

        let starting = { registers = registers; position = 12; mulCalls = 0 }
        let ending = applyRec starting instructions
        ending.registers.['h']

    