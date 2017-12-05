using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Code
{
    class Day04
    {
        public static int Solve(IEnumerable<IEnumerable<string>> indata)
        {
            return indata.Count(IsValid);
        }

        public static int Solve2(IEnumerable<IEnumerable<string>> indata)
        {
            return indata.Count(IsValid2);
        }


        public static bool IsValid(string phrase)
        {
            var words = phrase.Split(' ');
            return IsValid(words);
        }


        public static bool IsValid(IEnumerable<string> phrase)
        {
            return phrase.Distinct().Count() == phrase.Count();
        }


        public static bool IsValid2(string phrase)
        {
            var words = phrase.Split(' ');
            return IsValid2(words);
        }


        public static bool IsValid2(IEnumerable<string> phrase)
        {
            return IsValid(phrase) && NoAnagrams(phrase);
        }


        public static bool NoAnagrams(IEnumerable<string> phrase)
        {
            var charSorted = phrase.Select(word => new string(word.ToCharArray().OrderBy(c => c).ToArray()));
            return IsValid(charSorted);
        }
    }
}
