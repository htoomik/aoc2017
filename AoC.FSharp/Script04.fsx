#load "Day04.fs"

open System.IO
open AoC.FSharp

let d4 = File.ReadAllLines(@"C:\Code\AoC 2017\input_04.txt")
Seq.filter Day04.solve d4 |> Seq.length
Seq.filter Day04.solve2 d4 |> Seq.length