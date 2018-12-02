namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test24() =
    let d1 = [|
                "0/2";
                "2/2";
                "2/3";
                "3/4";
                "3/5";
                "0/1";
                "10/1";
                "9/10"
        |]

    [<Test>]
    member __.Example1() =
        Assert.That(Day24.solve d1, Is.EqualTo(31))