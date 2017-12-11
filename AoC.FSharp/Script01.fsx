load "Day01.fs"

open System.IO
open AoC.FSharp

let d1 = File.ReadAllText(@"C:\Code\AoC 2017\input_01.txt").Trim()
Day01.solve d1
Day01.solve2 d1