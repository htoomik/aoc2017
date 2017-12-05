using System.Linq;

namespace AoC
{
    public class Day01
    {
        public static int Solve(string s)
        {
            var tokens = s.Select(t => int.Parse(t.ToString())).ToList();
            tokens.Add(tokens[0]);
            int sum = 0;
            for (int i = 0; i < tokens.Count - 1; i++)
            {
                if (tokens[i] == tokens[i + 1])
                    sum += tokens[i];
            }
            return sum;
        }


        public static int Solve2(string s)
        {
            var tokens = s.Select(t => int.Parse(t.ToString())).ToList();
            int sum = 0;
            int max = tokens.Count;
            for (int i = 0; i < max; i++)
            {
                var j = i + max / 2;
                if (j >= max)
                    j -= max;

                if (tokens[i] == tokens[j])
                    sum += tokens[i];
            }
            return sum;
        }
    }
}
