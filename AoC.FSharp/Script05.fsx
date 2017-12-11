#load "Day05.fs"

open System.IO
open AoC.FSharp

let lines = File.ReadAllLines(@"C:\Code\AOC 2017\input_05.txt")
let d5 = Seq.map (fun line -> int line) lines
Day05.solve d5
Day05.solve2 d5