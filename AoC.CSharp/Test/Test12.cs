using AoC.Code;
using NUnit.Framework;
using System;
using System.IO;

namespace AoC.Test
{
    [TestFixture]
    public class Test12
    {
        [Test]
        public void Example1()
        {
            var input = new[] {
                "0 <-> 2",
                "1 <-> 1",
                "2 <-> 0, 3, 4",
                "3 <-> 2, 4",
                "4 <-> 2, 3, 6",
                "5 <-> 6",
                "6 <-> 4, 5"
            };
            Assert.That(Day12.Solve(input).Item1, Is.EqualTo(6));
            Assert.That(Day12.Solve(input).Item2, Is.EqualTo(2));
        }


        [Test]
        public void Solve1()
        {
            var indata = File.ReadAllLines(@"C:\Code\AoC 2017\input_12.txt");
            Console.WriteLine(Day12.Solve(indata));
        }
    }
}
