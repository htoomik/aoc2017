#load "Day13.fs"

open System.IO
open AoC.FSharp

let d = File.ReadAllLines(@"C:\Code\AoC 2017\input_13.txt")
printfn "part 1: %A" (Day13.solve1 d)
printfn "part 2: %A" (Day13.solve2 d)