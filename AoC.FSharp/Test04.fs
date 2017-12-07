namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test04() =
    [<Test>]
    member __.Examples1() =
        Assert.That(Day04.solve "aa bb cc dd ee", Is.True)
        Assert.That(Day04.solve "aa bb cc dd aa", Is.False)
        Assert.That(Day04.solve "aa bb cc dd aaa", Is.True)
    
    [<Test>]
    member __.Examples2() =
        Assert.That(Day04.solve2 "abcde fghij", Is.True)
        Assert.That(Day04.solve2 "abcde xyz ecdab", Is.False)
        Assert.That(Day04.solve2 "a ab abc abd abf abj", Is.True)
        Assert.That(Day04.solve2 "iiii oiii ooii oooi oooo", Is.True)
        Assert.That(Day04.solve2 "oiii ioii iioi iiio", Is.False)