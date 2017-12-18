#load "Day18.fs"
#load "Day18part2.fs"

open AoC.FSharp
open System.IO

let indata = File.ReadAllLines(@"C:\Code\AoC 2017\input_18.txt")
//printfn "part 1: %A" (Day18.solve indata)
printfn "part 2: %A" (Day18part2.solve indata [|'a'; 'b'; 'i';'f'; 'p'|])
