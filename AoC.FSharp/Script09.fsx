#load "Day09.fs"

open System.IO
open AoC.FSharp

let d9 = File.ReadAllText(@"C:\Code\AoC 2017\input_09.txt").Trim()
Day09.solve d9