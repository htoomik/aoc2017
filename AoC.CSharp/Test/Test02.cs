using AoC.Code;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Test
{
    [TestFixture]
    class Test02
    {
        [Test]
        public void Examples1()
        {
            var indata = new List<int[]>
            {
                new [] { 5, 1, 9, 5 },
                new [] { 7, 5, 3 },
                new [] { 2, 4, 6, 8 }
            };
            Assert.That(Day02.Solve(indata), Is.EqualTo(18));
        }


        [Test]
        public void Step1()
        {
            var rows = File.ReadAllLines(@"c:\code\aoc 2017\input_02.txt");
            var indata = rows.Select(r => r.Split('\t').Select(t => int.Parse(t)));
            Console.WriteLine(Day02.Solve(indata));
        }


        [Test]
        public void Examples2()
        {
            var indata = new List<int[]>
            {
                new [] { 5, 9, 2, 8 },
                new [] { 9, 4, 7, 3 },
                new [] { 3, 8, 6, 5 }
            };
            Assert.That(Day02.Solve2(indata), Is.EqualTo(9));
        }


        [Test]
        public void Step2()
        {
            var rows = File.ReadAllLines(@"c:\code\aoc 2017\input_02.txt");
            var indata = rows.Select(r => r.Split('\t').Select(t => int.Parse(t)));
            Console.WriteLine(Day02.Solve2(indata));
        }
    }
}
