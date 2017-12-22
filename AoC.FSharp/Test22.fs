namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test22() =
    let start = [
        "..#";
        "#..";
        "..."
        ]
    [<Test>]
    member __.Example1() =
        Assert.That(Day22.solve1 start 7, Is.EqualTo(5))

    [<Test>]
    member __.Example2() =
        Assert.That(Day22.solve1 start 70, Is.EqualTo(41))

    [<Test>]
    member __.Example3() =
        Assert.That(Day22.solve1 start 10000, Is.EqualTo(5587))

    [<Test>]
    member __.Step2Example1() =
        Assert.That(Day22.solve2 start 100, Is.EqualTo(26))

    [<Test>]
    member __.Step2Example2() =
        Assert.That(Day22.solve2 start 10000000, Is.EqualTo(2511944))