namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test08() =
    [<Test>]
    member __.Examples() =
        let indata = [
            "b inc 5 if a > 1";
            "a inc 1 if b < 5";
            "c dec -10 if a >= 1";
            "c inc -20 if c == 10"
        ]
        let (finalMax, runningMax) = Day08.solve indata
        Assert.That(finalMax, Is.EqualTo(1))
        Assert.That(runningMax, Is.EqualTo(10))
