#load "Day23.fs"

open AoC.FSharp
open System.IO

let indata = File.ReadAllLines(@"C:\Code\aoc2017\input_23.txt")
//printfn "part 1: %A" (Day23.solve indata)
printfn "part 2: %A" (Day23.solve2 indata)

// giving up on part 2 as it needs optimization which I don't enjoy
