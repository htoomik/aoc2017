namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test10() =
    [<Test>]
    member __.ExampleTwist() =
        let expected = [2; 1; 0; 3; 4]
        let actual = Day10.twist [0; 1; 2; 3; 4] 0 2
        CollectionAssert.AreEqual(expected, actual)

    [<Test>]
    member __.ExampleTwist2() =
        let e2 = [ 4; 3; 2; 1; 0 ]
        let a2 = Day10.twist [0; 1; 2; 3; 4] 3 1
        CollectionAssert.AreEqual(e2, a2)

    [<Test>]
    member __.ExampleTwist3() =
        let e2 = [ 6; 5; 2; 3; 4; 1; 0 ]
        let a2 = Day10.twist [0; 1; 2; 3; 4; 5; 6] 5 1
        CollectionAssert.AreEqual(e2, a2)
    
    [<Test>]
    member __.ExampleStep1() =
        Assert.That(Day10.solve1 4 "3,4,1,5", Is.EqualTo(12))

    [<Test>]
    member __.ExampleAdjustInput() =
        let expected = [| 49; 44; 50; 44; 51; 17; 31; 73; 47; 23 |]
        Assert.That(Day10.adjustInput "1,2,3", Is.EqualTo(expected))

    [<Test>]
    member __.ExampleDensify() =
        let data = [| 65; 27; 9; 1; 4; 3; 40; 50; 91; 7; 6; 0; 2; 5; 68; 22 |]
        Assert.That(Day10.densify data, Is.EqualTo(64))
        
    [<Test>]
    member __.ExampleToHex() =
        let data = [| 64; 7; 255 |]
        Assert.That(Day10.toHex data, Is.EqualTo("4007ff"))

    [<Test>]
    member __.ExampleStep2() = 
        Assert.That(Day10.solve2 "", Is.EqualTo("a2582a3a0e66e6e86e3812dcb672a272"))
        Assert.That(Day10.solve2 "AoC 2017", Is.EqualTo("33efeb34ea91902bb2f59c9920caa6cd"))
        Assert.That(Day10.solve2 "1,2,3", Is.EqualTo("3efbe78a8d82f29979031a4aa0b16a9d"))
        Assert.That(Day10.solve2 "1,2,4", Is.EqualTo("63960835bcdc130f0b66d7ff4f6a5a8e"))