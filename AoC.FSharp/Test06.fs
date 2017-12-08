namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test06() =
    [<Test>]
    member __.Examples() =
        let solution = Day06.solve [ 0; 2; 7; 0 ]
        let (a, b) = solution
        Assert.That(a, Is.EqualTo(5))
        Assert.That(b, Is.EqualTo(4))