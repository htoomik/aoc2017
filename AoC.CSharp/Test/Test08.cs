using AoC.Code;
using NUnit.Framework;
using System;
using System.IO;

namespace AoC.Test
{
    [TestFixture]
    public class Test08
    {
        [Test]
        public void Examples()
        {
            var input = new[] {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };
            Assert.That(Day08.Solve(input).FinalMax, Is.EqualTo(1));
            Assert.That(Day08.Solve(input).RunningMax, Is.EqualTo(10));
        }


        [Test]
        public void Step1()
        {
            var input = File.ReadAllLines(@"C:\Code\AoC 2017\input_08.txt");
            Console.WriteLine(Day08.Solve(input));
        }
    }
}
