namespace AoC.FSharp.Test

open NUnit.Framework
open AoC.FSharp

[<TestFixture>]
type Test07() =
    [<Test>]
    member __.Examples() =
        let indata = [|
            "pbga (66)";
            "xhth (57)";
            "ebii (61)";
            "havc (66)";
            "ktlj (57)";
            "fwft (72) -> ktlj, cntj, xhth";
            "qoyq (66)";
            "padx (45) -> pbga, havc, qoyq";
            "tknk (41) -> ugml, padx, fwft";
            "jptl (61)";
            "ugml (68) -> gyxo, ebii, jptl";
            "gyxo (61)";
            "cntj (57)"
        |]
        Assert.That(Day07.solve indata, Is.EqualTo("tknk"))
