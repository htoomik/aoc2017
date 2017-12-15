#load "Day15.fs"

open AoC.FSharp

let n1 = 40000000
let n2 = 5000000
let sa = 679
let sb = 771
printfn "part 1: %A" (Day15.solve n1 sa sb)
printfn "part 2: %A" (Day15.solve2 n2 sa sb)
