namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test01() =
    [<Test>]
    member __.Examples1() =
        Assert.That(Day01.solve "1122", Is.EqualTo(3))
        Assert.That(Day01.solve "1111", Is.EqualTo(4))
        Assert.That(Day01.solve "1234", Is.EqualTo(0))
        Assert.That(Day01.solve "91212129", Is.EqualTo(9))

    [<Test>]
    member __.Examples2() =
        Assert.That(Day01.solve2 "1212", Is.EqualTo(6))
        Assert.That(Day01.solve2 "1221", Is.EqualTo(0))
        Assert.That(Day01.solve2 "123425", Is.EqualTo(4))
        Assert.That(Day01.solve2 "123123", Is.EqualTo(12))
        Assert.That(Day01.solve2 "12131415", Is.EqualTo(4))
