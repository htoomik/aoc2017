using AoC.Code;
using System;
using NUnit.Framework;

namespace AoC.Test
{
    [TestFixture]
    class Test03
    {
        [Test]
        public void Examples1()
        {
            Assert.That(Day03.Solve(12), Is.EqualTo(3));
            Assert.That(Day03.Solve(23), Is.EqualTo(2));
            Assert.That(Day03.Solve(1024), Is.EqualTo(31));
        }


        [Test]
        public void Step1()
        {
            Console.WriteLine(Day03.Solve(368078));
        }


        [Test]
        public void Examples2()
        {
            Assert.That(Day03.Solve2(800), Is.EqualTo(806));
        }


        [Test]
        public void Step2()
        {
            Console.WriteLine(Day03.Solve2(368078));
        }
    }
}
