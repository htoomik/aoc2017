#load "Day22.fs"

open AoC.FSharp
open System
open System.IO

let d = File.ReadAllLines(@"C:\Code\AoC 2017\input_22.txt") |> List.ofArray
printfn "part 1: %A" (Day22.solve1 d 10000)
printfn "part 2: %A" (Day22.solve2 d 10000000)