#load "Day05.fs"
#load "Day05_nm.fs"

open System.IO
open AoC.FSharp

let lines = File.ReadAllLines(@"C:\Code\AOC 2017\input_05.txt")
let d5 = Seq.map (fun line -> int line) lines
printfn "step 1 iterative: %A" (Day05.solve d5)
printfn "step 2 iterative: %A" (Day05.solve2 d5)

printfn "step 1 recursive: %A" (Day05_nm.solve (Seq.toList d5))
printfn "step 2 recursive: %A" (Day05_nm.solve2 (Seq.toList d5))