namespace AoC.FSharp

module Day22 =
    open System.Collections.Generic

    type Status = Clean | Weakened | Flagged | Infected
    type Position = int * int // row, col
    type Node = {
        pos: Position
        status: Status
    }
    type State = {
        pos: Position
        direction: Position
        nodes: Dictionary<Position, Status>
    }

    let shift shiftBy (pos: Position) =
        (fst(pos) - shiftBy, snd(pos) - shiftBy)
   
    let step position direction =
        (fst(position) + fst(direction), snd(position) + snd(direction))

    let getNewStatus status =
        match status with
        | Clean -> Infected
        | Infected -> Clean
        | _ -> failwith "Unexpected status for step 1"

    let getNewStatus2 status =
        match status with
        | Clean -> Weakened
        | Weakened -> Infected
        | Infected -> Flagged
        | Flagged -> Clean

    let mutate state statusFunc =
        let currentStatus = 
            if state.nodes.ContainsKey(state.pos) then
                state.nodes.[state.pos]
            else
                Clean

        let newStatus = statusFunc currentStatus
        let gotInfected = newStatus = Infected
        state.nodes.[state.pos] <- newStatus

        let newDirection = 
            if currentStatus = Infected then // turn right
                match state.direction with
                | (-1, 0) -> (0, 1)
                | (0, 1) -> (1, 0)
                | (1, 0) -> (0, -1)
                | (0, -1) -> (-1, 0)
                | (_, _) -> failwith "unexpected direction"
            elif currentStatus = Clean then // turn left
                match state.direction with
                | (-1, 0) -> (0, -1)
                | (0, 1) -> (-1, 0)
                | (1, 0) -> (0, 1)
                | (0, -1) -> (1, 0)
                | (_, _) -> failwith "unexpected direction"
            elif currentStatus = Weakened then // continue
                state.direction
            elif currentStatus = Flagged then //reverse
                (- fst(state.direction), - snd(state.direction))
            else
                failwith "wut"
        let newPosition = step state.pos newDirection

        let newState = { pos = newPosition; direction = newDirection; nodes = state.nodes }
        (newState, gotInfected)

    let rec iterate state statusFunc count n goal =
        let (newState, gotInfected) = mutate state statusFunc
        let newCount = count + (if gotInfected then 1 else 0)
        let newN = n + 1
        if newN = goal then
            (newState, newCount)
        else
            iterate newState statusFunc newCount newN goal
     
    let parseStatus c =
        if c = '#' then Infected else Clean

    let solve (start: string list) iters statusFunc = 
        let rawNodes = List.concat (List.mapi (fun r row -> List.ofSeq (Seq.mapi (fun c ch -> ((r, c), parseStatus ch)) row)) start)
        let shiftBy = (start.Length - 1) / 2
        let kvps = List.map (fun (pos, status) -> ((shift shiftBy pos), status)) rawNodes
        let (board: Dictionary<Position, Status>) = new Dictionary<Position, Status> (dict (kvps))

        let initialState = { pos = (0, 0); direction = (-1, 0); nodes = board }

        let (_, finalCount) = iterate initialState statusFunc 0 0 iters
        finalCount

    let solve1 start iters =
        solve start iters getNewStatus

    let solve2 start iters =
        solve start iters getNewStatus2      