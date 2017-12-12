﻿namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test05() =
    [<Test>]
    member __.Examples1() =
        Assert.That(Day05.solve [ 0; 3; 0; 1; -3], Is.EqualTo(5))

    [<Test>]
    member __.Examples2() =
        Assert.That(Day05.solve2 [ 0; 3; 0; 1; -3], Is.EqualTo(10))

    [<Test>]
    member __.Examples1_NonMutable() =
        Assert.That(Day05_nm.solve [ 0; 3; 0; 1; -3], Is.EqualTo(5))

    [<Test>]
    member __.Examples2_NonMutable() =
        Assert.That(Day05_nm.solve2 [ 0; 3; 0; 1; -3], Is.EqualTo(10))