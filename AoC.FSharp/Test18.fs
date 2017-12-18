namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test18() =
    let d1 = [|
            "set a 1 ";
            "add a 2 ";
            "mul a a ";
            "mod a 5 ";
            "snd a   ";
            "set a 0 ";
            "rcv a   ";
            "jgz a -1";
            "set a 1 ";
            "jgz a -2"
        |]

    let d2 = [|
            "snd 1";
            "snd 2";
            "snd p";
            "rcv a";
            "rcv b";
            "rcv c";
            "rcv d"
        |]

    [<Test>]
    member __.Example1() =
        Assert.That(Day18.solve d1, Is.EqualTo(4))

        
    [<Test>]
    member __.Example2() =
        Assert.That(Day18part2.solve d2 [|'a'; 'b'; 'c'; 'd'; 'p'|], Is.EqualTo(3))