#load "Day02.fs"

open System.IO
open AoC.FSharp

let lines = File.ReadAllLines(@"C:\Code\AoC 2017\input_02.txt")
let d2 = 
    lines 
    |> Seq.map (fun line -> 
        line.Trim().Split('\t') 
        |> Seq.map (fun s -> int s) 
        |> Seq.toList) 
    |> Seq.toList
Day02.solve d2
Day02.solve2 d2