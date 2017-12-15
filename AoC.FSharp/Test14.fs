namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test14() =
    let input = "flqrgnkx"

    [<Test>]
    member __.ToBin() =
        let indata = "a0c2017"
        let actual = Day14.toBin indata
        let expected = "1010000011000010000000010111"
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member __.Example1() =
        let expected = 8108
        let actual = Day14.solve1 input
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member __.Example2() =
        let expected = 1242
        let actual = Day14.solve2 input
        Assert.That(actual, Is.EqualTo(expected))