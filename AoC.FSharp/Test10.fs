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
        Assert.That(Day10.solve 4 "3,4,1,5", Is.EqualTo(12))
