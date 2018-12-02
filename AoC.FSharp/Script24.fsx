#load "Day24.fs"

open AoC.FSharp
open System.IO

let indata = File.ReadAllLines(@"C:\Code\aoc2017\input_24.txt")
printfn "part 1: %A" (Day24.solve indata)
