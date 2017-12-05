using AoC.Code;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace AoC.Test
{
    [TestFixture]
    class Test05
    {
        [Test]
        public void Examples1()
        {
            var indata = new[] { 0, 3, 0, 1, -3 };
            Assert.That(Day05.Solve(indata), Is.EqualTo(5));
        }


        [Test]
        public void Step1()
        {
            var rows = File.ReadAllLines(@"c:\code\aoc 2017\input_05.txt");
            var indata = rows.Select(r => int.Parse(r.Trim()));
            Console.WriteLine(Day05.Solve(indata));
        }


        [Test]
        public void Examples2()
        {
            var indata = new[] { 0, 3, 0, 1, -3 };
            Assert.That(Day05.Solve2(indata), Is.EqualTo(10));
        }


        [Test]
        public void Step2()
        {
            var rows = File.ReadAllLines(@"c:\code\aoc 2017\input_05.txt");
            var indata = rows.Select(r => int.Parse(r.Trim()));
            Console.WriteLine(Day05.Solve2(indata));
        }
    }
}
