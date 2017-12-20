namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test20() =
    [<Test>]
    member __.TestStep1() =
        let d = [
            "p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>";
            "p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>"
        ]
        let actual = Day20.solve d false
        Assert.That(actual, Is.EqualTo(0))
