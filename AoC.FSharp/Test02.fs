namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test02() =
    [<Test>]
    member __.Examples1() =
        let indata = 
            [
                [ 5; 1; 9; 5 ];
                [ 7; 5; 3 ];
                [ 2; 4; 6; 8 ]
            ]
        Assert.That(Day02.solve indata, Is.EqualTo(18))

    [<Test>]
    member __.Examples2() =
        let indata = 
            [
                [ 5; 9; 2; 8 ];
                [ 9; 4; 7; 3 ];
                [ 3; 8; 6; 5 ]
            ]
        Assert.That(Day02.solve2 indata, Is.EqualTo(9))