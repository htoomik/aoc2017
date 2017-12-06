using AoC.Code;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace AoC.Test
{
    [TestFixture]
    public class Test06
    {
        [Test]
        public void Examples1()
        {
            var result = Day06.Solve(new[] { 0, 2, 7, 0 });
            Assert.That(result.Item1, Is.EqualTo(5));
            Assert.That(result.Item2, Is.EqualTo(4));
        }


        [Test]
        public void Step1()
        {
            var data = File.ReadAllText(@"C:\code\aoc 2017\input_06.txt").Trim().Split('\t').Select(s => int.Parse(s));
            Console.WriteLine(Day06.Solve(data));
        }
    }
}
