namespace AoC.FSharp

open System
open System.Collections.Generic

module Day24 =

    type Component = {
        one: string
        two: string
    }

    type State = {
        used: Component seq
        unused: Component seq
        strength: int
        this: Component
    }

    let parse (rows: string[]) =
        rows
        |> Seq.map (fun row -> row.Split('/'))
        |> Seq.map (fun a -> { one = a.[0]; two = a.[1] })

    let isStarter comp =
        comp.one = "0" || comp.two = "0"

    let findStarters (pairs) =
        Seq.filter isStarter pairs
    
    let measure comp =
        let avalue = comp.one |> int
        let bvalue = comp.two |> int
        avalue + bvalue

    let rec tryAll state =
        state

    let solve (rows: string[]) =
        let components = parse rows
        let starters = findStarters components
        
        Seq.fold (fun i comp -> 
            let initialState = { unused = components; strength = 0; used = Seq.empty; this = comp }
            let best = tryAll initialState
            best.strength
            ) 0 starters

        