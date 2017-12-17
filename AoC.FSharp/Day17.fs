namespace AoC.FSharp

open System

module Day17 =
    type State = {
        buffer: int[]
        position: int
    }

    let insert value step state =
        //printfn "%A" state.buffer
        let insertAfter = (state.position + step) % state.buffer.Length
        let newBuffer = Array.append (Array.append state.buffer.[0..insertAfter] [| value |]) state.buffer.[insertAfter + 1 .. state.buffer.Length - 1]
        let newPosition = (insertAfter + 1) % newBuffer.Length
        { buffer = newBuffer; position = newPosition }

    let generate step max = 
        let start = { buffer = [|0|]; position = 0 }
        let result = List.fold (fun state i -> insert i step state) start [1..max]
        result.buffer

    let solve1 step max find =
        let result = generate step max
        let index = Array.findIndex ((=) find) result
        result.[index + 1]
    
    type State2 = {
        bufferLength: int
        after0: int
        position: int
    }

    let move value step state =
        let insertAfter = (state.position + step) % state.bufferLength
        let newBufferLength = state.bufferLength + 1
        let newPosition = (insertAfter + 1) % newBufferLength
        let newAfter0 = if insertAfter = 0 then value else state.after0
        { bufferLength = newBufferLength; after0 = newAfter0; position = newPosition }

    let solve2 step max =
        let start = { bufferLength = 1; after0 = 0; position = 0 }
        let result = List.fold (fun state i -> move i step state) start [1..max]
        result.after0

