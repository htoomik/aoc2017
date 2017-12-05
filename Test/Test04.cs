using AoC.Code;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace AoC.Test
{
    [TestFixture]
    class Test04
    {
        [Test]
        public void Examples1()
        {
            Assert.That(Day04.IsValid(new[] { "aa", "bb", "cc", "dd", "ee" }), Is.True);
            Assert.That(Day04.IsValid(new[] { "aa", "bb", "cc", "dd", "aa" }), Is.False);
            Assert.That(Day04.IsValid(new[] { "aa", "bb", "cc", "dd", "aaa" }), Is.True);
        }


        [Test]
        public void Step1()
        {
            var rows = File.ReadAllLines(@"C:\Code\AoC 2017\input_04.txt");
            var phrases = rows.Select(r => r.Split(' '));
            Console.WriteLine(Day04.Solve(phrases));
        }


        [Test]
        public void Examples2()
        {
            Assert.That(Day04.IsValid2("abcde fghij"), Is.True);
            Assert.That(Day04.IsValid2("abcde xyz ecdab"), Is.False);
            Assert.That(Day04.IsValid2("a ab abc abd abf abj"), Is.True);
            Assert.That(Day04.IsValid2("iiii oiii ooii oooi oooo"), Is.True);
            Assert.That(Day04.IsValid2("oiii ioii iioi iiio"), Is.False);
        }


        [Test]
        public void Step2()
        {
            var rows = File.ReadAllLines(@"C:\Code\AoC 2017\input_04.txt");
            var phrases = rows.Select(r => r.Split(' '));
            Console.WriteLine(Day04.Solve2(phrases));
        }
    }
}
