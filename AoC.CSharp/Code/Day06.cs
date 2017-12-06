using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Code
{
    public class Day06
    {
        public static Tuple<int, int> Solve(IEnumerable<int> input)
        {
            var counter = 0;
            var seen = new Dictionary<string, int>();
            var state = input.ToList();

            var hash = string.Join(",", state);
            seen.Add(hash, counter);

            while (true)
            {
                counter++;
                state = Redistribute(state);
                hash = string.Join(",", state);
                //Console.WriteLine($"Run {counter} - state: {hash}");
                if (seen.ContainsKey(hash))
                    break;
                seen.Add(hash, counter);
            }
            return new Tuple<int, int>(counter, counter - seen[hash]);
        }


        private static List<int> Redistribute(List<int> state)
        {
            var max = state.Max();
            var indexOfMax = state.IndexOf(max);

            var newState = new List<int>(state);
            newState[indexOfMax] = 0;

            var j = indexOfMax + 1;
            if (j == state.Count)
                    j = 0;

            for (var i = 0; i < max; i++)
            {
                newState[j]++;
                j++;
                if (j == state.Count)
                    j = 0;
            }

            if (state.Sum() != newState.Sum())
                throw new Exception("total does not match!");

            return newState;
        }
    }
}
