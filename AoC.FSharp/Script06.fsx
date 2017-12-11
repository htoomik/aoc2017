#load "Day06.fs"

open System.IO
open AoC.FSharp

let s = File.ReadAllText(@"C:\Code\AoC 2017\input_06.txt").Trim()
let d6 = Array.map (fun x -> int x) (s.Split('\t'))
Day06.solve d6