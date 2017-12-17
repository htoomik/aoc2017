#load "Day16.fs"

open AoC.FSharp
open System
open System.IO

let a = Array.ofSeq "abcdefghijklmnop"

let d = File.ReadAllText(@"C:\Code\AoC 2017\input_16.txt").Trim().Split(',')
//let r1 = Day16.solve1 a d
//printfn "part 1: %A" (String.Concat r1)

let n = 200
let r2 = Day16.solve2 a d n
printfn "part 2 with n = %A: %A" n (String.Concat r2)