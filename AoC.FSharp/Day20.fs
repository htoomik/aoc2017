namespace AoC.FSharp

open System

module Day20 =
    type Point = {
        i: int
        pos: int * int * int
        v: int * int * int
        acc: int * int * int
    }

    let parseOne (chunk: string) =
        let cleaned = chunk.[3..(chunk.Length - 2)]
        let parts = cleaned.Split(',')
        (int parts.[0], int parts.[1], int parts.[2])

    let parse i (line: string) =
        let parts = line.Split([|", "|], StringSplitOptions.None)
        let pos = parseOne parts.[0]
        let v = parseOne parts.[1]
        let acc = parseOne parts.[2]
        { i = i; pos = pos; v = v; acc = acc }
    
    let distance (point: Point) =
        let (x, y, z) = point.pos
        let d = abs(x) + abs(y) + abs(z)
        //printfn "Point %A is at distance %A" point.i d
        d
    
    let move (point: Point) =
        let (x, y, z) = point.pos
        let (vx, vy, vz) = point.v
        let (accx, accy, accz) = point.acc
        let (newvx, newvy, newvz) = (vx + accx, vy + accy, vz + accz)
        //printfn "Point %A velocity is (%A, %A, %A)" point.i newvx newvy newvz
        let (newx, newy, newz) = (x + newvx, y + newvy, z + newvz)
        //printfn "Point %A moves to (%A, %A, %A)" point.i newx newy newz
        { i = point.i; pos = (newx, newy, newz); v = (newvx, newvy, newvz); acc = point.acc }
    
    let collided point points =
        let collisions = List.filter (fun p -> p.pos = point.pos && p.i <> point.i) points
        if not (collisions.IsEmpty) then 
            //printfn "Point %A collided with point %A at %A" point.i collisions.[0].i point.pos
            true
        else
            false

    let findClosest (points: Point list) =
        //printfn "Looking for the closest point among %A" points.Length
        let closestPoint = List.minBy (fun p -> distance p) points
        closestPoint.i
    
    let moveAll points result timeUnchanged killCollisions resultFunction =
        let movedPoints = List.map move points
        let adjustedPoints = 
            if killCollisions then
                let collisions =  List.filter (fun point -> collided point movedPoints) movedPoints
                //printfn "Removing points %A" (String.concat " " (List.map (fun p -> p.i.ToString()) collisions))
                let exCollisions = List.filter (fun point -> not (List.contains point collisions)) movedPoints
                //printfn "%A points left after collisions - %A" exCollisions.Length (String.concat " " (List.map (fun p -> p.i.ToString()) exCollisions))
                exCollisions
            else
                movedPoints
        let newResult = resultFunction adjustedPoints
        let newTime = if newResult = result then timeUnchanged + 1 else 1
        //printfn "Point %A is closest, and has been closest %A times" newClosest newTime
        (adjustedPoints, newResult, newTime)

    let rec solveRec1 points closest timeAsClosest n =
        if timeAsClosest > 1000 then
            closest
        elif n > 10000 then
            printfn "Giving up"
            closest
        else
            let (newPoints, newClosest, newTime) = moveAll points closest timeAsClosest false findClosest
            solveRec1 newPoints newClosest newTime (n + 1)

    let rec solveRec2 (points: Point list) count timeUnchanged n =
        if timeUnchanged > 100 then
            points.Length
        elif n > 10000 then
            printfn "Giving up"
            points.Length
        else
            let (newPoints, newCount, newTime) = (moveAll points count timeUnchanged true (fun points -> points.Length))
            solveRec2 newPoints newCount newTime (n + 1)

    let solve1 (d: string list) =
        let points = List.mapi (fun line i-> parse line i) d
        printfn "%A" points

        let initialClosest = findClosest points
        printfn "Point %A is closest initially" initialClosest

        solveRec1 points initialClosest 0 0

    let solve2 (d: string list) =
        let points = List.mapi (fun line i-> parse line i) d
        printfn "%A" points

        let initialCount = points.Length
        printfn "Initial count %A" initialCount
        
        solveRec2 points initialCount 0 0