namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test17() =
    [<Test>]
    member __.TestGenerate() =
        Assert.That(Day17.generate 3 9, Is.EqualTo([|0; 9; 5; 7; 2; 4; 3; 8; 6; 1|]))
        
    [<Test>]
    member __.TestStep1() =
        Assert.That(Day17.solve1 3 2017 2017, Is.EqualTo(638))

    [<Test>]
    member __.TestStep2() =
        Assert.That(Day17.solve2 3 9, Is.EqualTo(9))
