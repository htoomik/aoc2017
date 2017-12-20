#load "Day20.fs"

open AoC.FSharp
open System
open System.IO

let d = File.ReadAllLines(@"C:\Code\AoC 2017\input_20.txt") |> List.ofArray
// printfn "part 1: %A" (Day20.solve d false)
// 308

printfn "part 2: %A" (Day20.solve d true)
// part 2: 905 is wrong
