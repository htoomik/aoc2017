namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test01() =
    [<Test>]
    member __.Example1() =
        let actual = Day01.solve "1122"
        Assert.That(actual, Is.EqualTo(4))