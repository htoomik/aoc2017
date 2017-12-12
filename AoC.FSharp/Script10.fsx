#load "Day10.fs"

open System.IO
open AoC.FSharp

let d = File.ReadAllText(@"C:\Code\AoC 2017\input_10.txt").Trim()
Day10.solve 255 d