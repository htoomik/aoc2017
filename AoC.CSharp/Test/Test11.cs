using AoC.Code;
using NUnit.Framework;
using System;
using System.IO;

namespace AoC.Test
{
    [TestFixture]
    public class Test11
    {
        [Test]
        public void Examples1()
        {
            Assert.That(Day11.Solve("ne,ne,ne").Item1, Is.EqualTo(3));
            Assert.That(Day11.Solve("ne,ne,sw,sw").Item1, Is.EqualTo(0));
            Assert.That(Day11.Solve("ne,ne,s,s").Item1, Is.EqualTo(2));
            Assert.That(Day11.Solve("se,sw,se,sw,sw").Item1, Is.EqualTo(3));
        }


        [Test]
        public void Step1()
        {
            var indata = File.ReadAllLines(@"C:\Code\AoC 2017\input_11.txt")[0];
            Console.WriteLine(Day11.Solve(indata));
        }
    }
}
