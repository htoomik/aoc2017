namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test15() =
    let sa = 65
    let sb = 8921

    [<Test>]
    member __.TestGeneratorA() =
        let actual = Day15.generator sa 16807 5
        let expected = [
               1092455;
            1181022009;
             245556042;
            1744312007;
            1352636452
        ]
        CollectionAssert.AreEqual(expected, actual)

    [<Test>]
    member __.TestGeneratorB() =
        let actual = Day15.generator sb 48271 5
        let expected = [
             430625591;
            1233683848;
            1431495498;
             137874439;
             285222916
        ]
        CollectionAssert.AreEqual(expected, actual)

    [<Test>]
    member __.Example1() =
        Assert.That(Day15.solve 5 sa sb, Is.EqualTo(1))
        Assert.That(Day15.solve 40000000 sa sb, Is.EqualTo(588))
    
    [<Test>]
    member __.TestGeneratorA2() =
        let actual = Day15.generator2a sa 16807 5
        let expected = [
            1352636452;
            1992081072;
             530830436;
            1980017072;
             740335192
        ]
        CollectionAssert.AreEqual(expected, actual)

    [<Test>]
    member __.TestGeneratorB2() =
        let actual = Day15.generator2b sb 48271 5
        let expected = [
            1233683848;
             862516352;
            1159784568;
            1616057672;
             412269392
        ]
        CollectionAssert.AreEqual(expected, actual)

    [<Test>]
    member __.Example2() =
        Assert.That(Day15.solve2 1056 sa sb, Is.EqualTo(1))
        Assert.That(Day15.solve2 5000000 sa sb, Is.EqualTo(309))