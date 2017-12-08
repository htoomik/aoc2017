#load "Day06.fs"

open System.IO
open AoC.FSharp

//let d1 = File.ReadAllText(@"C:\Code\AoC 2017\input_01.txt").Trim()
//Day01.solve d1
//Day01.solve2 d1

//let lines = File.ReadAllLines(@"C:\Code\AoC 2017\input_02.txt")
//let d2 = 
//    lines 
//    |> Seq.map (fun line -> 
//        line.Trim().Split('\t') 
//        |> Seq.map (fun s -> int s) 
//        |> Seq.toList) 
//    |> Seq.toList
//Day02.solve d2
//Day02.solve2 d2

//let d4 = File.ReadAllLines(@"C:\Code\AoC 2017\input_04.txt")
//Seq.filter Day04.solve d4 |> Seq.length
//Seq.filter Day04.solve2 d4 |> Seq.length

//let lines = File.ReadAllLines(@"C:\Code\AOC 2017\input_05.txt")
//let d5 = Seq.map (fun line -> int line) lines
//Day05.solve d5
//Day05.solve2 d5

let s = File.ReadAllText(@"C:\Code\AoC 2017\input_06.txt").Trim()
let d6 = Array.map (fun x -> int x) (s.Split('\t'))
Day06.solve d6
