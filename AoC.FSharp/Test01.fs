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