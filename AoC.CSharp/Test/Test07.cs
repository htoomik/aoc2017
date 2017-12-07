using AoC.Code;
using NUnit.Framework;
using System;
using System.IO;

namespace AoC.Test
{
    [TestFixture]
    class Test07
    {
        private static readonly string[] data = new[]
            {
                "pbga (66)",
                "xhth (57)",
                "ebii (61)",
                "havc (66)",
                "ktlj (57)",
                "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)",
                "padx (45) -> pbga, havc, qoyq",
                "tknk (41) -> ugml, padx, fwft",
                "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl",
                "gyxo (61)",
                "cntj (57)"
            };


        [Test]
        public void Examples1()
        {
            Assert.That(Day07.Solve(data), Is.EqualTo("tknk"));
        }


        [Test]
        public void Step1()
        {
            var indata = File.ReadAllLines(@"C:\Code\Aoc 2017\input_07.txt");
            Console.WriteLine(Day07.Solve(indata));
        }


        [Test]
        public void Examples2()
        {
            Assert.That(Day07.Solve2(data), Is.EqualTo(60));
        }


        [Test]
        public void Step2()
        {
            var indata = File.ReadAllLines(@"C:\Code\Aoc 2017\input_07.txt");
            Console.WriteLine(Day07.Solve2(indata));
        }
    }
}
