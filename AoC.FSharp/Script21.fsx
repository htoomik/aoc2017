#load "Day21.fs"

open AoC.FSharp
open System
open System.IO

let d = File.ReadAllLines(@"C:\Code\AoC 2017\input_21.txt") |> List.ofArray
printfn "part 1: %A" (Day21.solve d 5)
printfn "part 2: %A" (Day21.solve d 18)
