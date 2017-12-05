using NUnit.Framework;
using System;
using System.IO;

namespace AoC.Test
{
    [TestFixture]
    public class Test01
    {
        [Test]
        public void Examples1()
        {
            Assert.That(Day01.Solve("1111"), Is.EqualTo(4));
            Assert.That(Day01.Solve("1122"), Is.EqualTo(3));
            Assert.That(Day01.Solve("1234"), Is.EqualTo(0));
            Assert.That(Day01.Solve("91212129"), Is.EqualTo(9));
        }


        [Test]
        public void Step1()
        {
            var s = File.ReadAllText(@"c:\code\aoc 2017\input_01.txt").Trim();
            Console.WriteLine(Day01.Solve(s));
        }


        [Test]
        public void Examples2()
        {
            Assert.That(Day01.Solve2("1212"), Is.EqualTo(6));
            Assert.That(Day01.Solve2("1221"), Is.EqualTo(0));
            Assert.That(Day01.Solve2("123425"), Is.EqualTo(4));
            Assert.That(Day01.Solve2("123123"), Is.EqualTo(12));
            Assert.That(Day01.Solve2("12131415"), Is.EqualTo(4));
        }


        [Test]
        public void Step2()
        {
            var s = File.ReadAllText(@"c:\code\aoc 2017\input_01.txt").Trim();
            Console.WriteLine(Day01.Solve2(s));
        }
    }
}
