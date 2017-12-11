namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test09() =
    [<Test>]
    member __.Examples1() =
        Assert.That(Day09.solve("{}").sc, Is.EqualTo(1))
        Assert.That(Day09.solve("{{{}}}").sc, Is.EqualTo(6))
        Assert.That(Day09.solve("{{},{}}").sc, Is.EqualTo(5))
        Assert.That(Day09.solve("{{{},{},{{}}}}").sc, Is.EqualTo(16))
        Assert.That(Day09.solve("{<a>,<a>,<a>,<a>}").sc, Is.EqualTo(1))
        Assert.That(Day09.solve("{{<ab>},{<ab>},{<ab>},{<ab>}}").sc, Is.EqualTo(9))
        Assert.That(Day09.solve("{{<!!>},{<!!>},{<!!>},{<!!>}}").sc, Is.EqualTo(9))
        Assert.That(Day09.solve("{{<a!>},{<a!>},{<a!>},{<ab>}}").sc, Is.EqualTo(3))
        ()

    [<Test>]
    member __.Examples2() =
        Assert.That(Day09.solve("<>").g, Is.EqualTo(0))
        Assert.That(Day09.solve("<random characters>").g, Is.EqualTo(17))
        Assert.That(Day09.solve("<<<<>").g, Is.EqualTo(3))
        Assert.That(Day09.solve("<{!>}>").g, Is.EqualTo(2))
        Assert.That(Day09.solve("<!!>").g, Is.EqualTo(0))
        Assert.That(Day09.solve("<!!!>>").g, Is.EqualTo(0))
        Assert.That(Day09.solve("<{o\"i!a,<{i<a>").g, Is.EqualTo(10))
        ()