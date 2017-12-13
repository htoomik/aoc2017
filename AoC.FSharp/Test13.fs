namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test13() =
    let input = [| 
        "0: 3";
        "1: 2";
        "4: 4";
        "6: 4" |]

    [<Test>]
    member __.Example1() =
        let expected = 24
        let actual = Day13.solve1 input
        Assert.That(actual, Is.EqualTo(expected))

        
    [<Test>]
    member __.Example2() =
        let expected = 10
        let actual = Day13.solve2 input
        Assert.That(actual, Is.EqualTo(expected))