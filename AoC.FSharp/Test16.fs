namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test16() =
    let s = "abcde"

    [<Test>]
    member __.TestSpin() =
        let a = Array.ofSeq s
        Assert.That(Day16.spin 3 a, Is.EqualTo([| 'c'; 'd'; 'e'; 'a'; 'b' |]))

    [<Test>]
    member __.TestExchange() =
        let a = Array.ofSeq s
        Assert.That(Day16.exchange 3 4 a, Is.EqualTo([| 'a'; 'b'; 'c'; 'e'; 'd' |]))

    [<Test>]
    member __.TestPartner() =
        let a = Array.ofSeq s
        Assert.That(Day16.partner 'e' 'b' a, Is.EqualTo([| 'a'; 'e'; 'c'; 'd'; 'b' |]))
    
    [<Test>]
    member __.Example1() =
        let a = Array.ofSeq s
        let instructions = [| "s1"; "x3/4"; "pe/b"  |]
        Assert.That(Day16.solve1 a instructions, Is.EqualTo("baedc"))

    [<Test>]
    member __.Example2() =
        let a = Array.ofSeq s
        let instructions = [| "s1"; "x3/4"; "pe/b"  |]
        Assert.That(Day16.solve2 a instructions 2, Is.EqualTo("ceadb"))