#load "Day01.fs"

open System.IO
open AoC.FSharp

let s = File.ReadAllText(@"C:\Code\AoC 2017\input_01.txt").Trim()
Day01.solve s
