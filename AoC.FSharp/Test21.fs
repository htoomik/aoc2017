namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test21() =
    [<Test>]
    member __.TestStep1() =
        let rules = [
            "../.# => ##./#../...";
            ".#./..#/### => #..#/..../..../#..#"
        ]
        let actual = Day21.solve rules 2
        Assert.That(actual, Is.EqualTo(12))
