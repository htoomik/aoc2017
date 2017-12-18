namespace AoC.FSharp

open System
open System.Collections.Generic

module Day18part2 =
    type State = {
        registers: Dictionary<char, int64>
        position: int
        sent: Option<int64>
        sendCount: int
        waiting: bool
    }

    let apply state (queue: int64 list) (instruction: string) =
        let parts = instruction.Trim().Split(' ')
        let reg = parts.[0]

        let part1 = parts.[1]
        let x = match System.Int64.TryParse(part1) with
                | (true, int) -> int
                | _ -> state.registers.[char part1]
        let part2 = if parts.Length = 3 then parts.[2] else ""
        let y = match part2 with
                | "" -> 0L
                | s -> match System.Int64.TryParse(s) with
                       | (true, int) -> int
                       | _ -> state.registers.[char s]

        let sent = if reg = "snd" then Some x else None
        let sendCount = match sent with
                        | Some _ -> state.sendCount + 1 
                        | None -> state.sendCount
        let waiting = reg = "rcv" && queue.Length = 0
        let newQueue = if reg = "rcv" && not waiting then queue.Tail else queue
        let position = 
            if reg = "jgz" && x > 0L then 
                state.position + (int y) 
            elif waiting then
                state.position
            else 
                state.position + 1
        let newX = match reg with
                   | "set" -> y
                   | "add" -> x + y
                   | "mul" -> x * y
                   | "mod" -> x % y
                   | "rcv" -> if queue.Length > 0 then queue.Head else 0L
                   | _ -> x
        state.registers.[char part1] <- newX

        let newState = { 
            registers = state.registers;
            sent = sent; 
            position = position; 
            sendCount = sendCount;
            waiting = waiting
        }
        (newState, newQueue)
    
    let oob state (instructions: string[]) =
        state.position < 0 || state.position >= instructions.Length

    let rec applyRec state0 state1 queue0 queue1 (instructions: string[]) =
        let oob0 = oob state0 instructions
        let oob1 = oob state1 instructions
        let waiting0 = state0.waiting
        let waiting1 = state1.waiting

        let finished = (oob0 && oob1) || (waiting0 && waiting1)
        if finished then
            state1
        else
            let queueFor0 = match state1.sent with
                            | Some i -> List.append queue0 [i]
                            | None -> queue0
            let queueFor1 = match state0.sent with
                            | Some i -> List.append queue1 [i]
                            | None -> queue1
            let (newState0, newQueue0) = apply state0 queueFor0 instructions.[state0.position]
            let (newState1, newQueue1) = apply state1 queueFor1 instructions.[state1.position]
            applyRec newState0 newState1 newQueue0 newQueue1 instructions

    let solve (instructions: string[]) keys =
        let registers0 = new Dictionary<char, int64> (dict (Array.map (fun c -> (c, 0L)) keys))
        let registers1 = new Dictionary<char, int64> (dict (Array.map (fun c -> (c, 0L)) keys))
        registers1.['p'] <- 1L
        let starting0 = { registers = registers0; position = 0; sent = None; sendCount = 0; waiting = false }
        let starting1 = { registers = registers1; position = 0; sent = None; sendCount = 0; waiting = false }
        let queue0 = []
        let queue1 = []
        let ending = applyRec starting0 starting1 queue0 queue1 instructions
        ending.sendCount

    