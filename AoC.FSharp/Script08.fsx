#load "Day08.fs"

open System.IO
open AoC.FSharp

let d8 = File.ReadAllLines(@"C:\Code\AoC 2017\input_08.txt")
Day08.solve d8
