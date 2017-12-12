using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Code
{
    public class Day12
    {
        public static Tuple<int, int> Solve(IEnumerable<string> indata)
        {
            var groups = indata
                .Select(s => s.Split(new[] { " <-> " }, StringSplitOptions.None))
                .Select(p => p[1].Split(',').Select(s => s.Trim()).Union(new[] { p[0] }).ToList()).ToList();

            var count1 = groups.Count();
            var count2 = 0;

            while (count1 != count2)
            {
                count1 = count2;
                groups = Merge(groups);
                count2 = groups.Count();
            }

            var zeroGroup = groups.Single(g => g.Contains("0"));
            return new Tuple<int, int>(zeroGroup.Count(), count2);
        }


        private static List<List<string>> Merge(List<List<string>> groups)
        {
            var result = new List<List<string>>();

            while (groups.Any())
            {
                var newGroup = groups.First();
                var connected = groups.Where(g => g.Intersect(newGroup).Any()).ToList();
                newGroup.AddRange(connected.SelectMany(g => g).ToList());
                foreach (var c in connected)
                    groups.Remove(c);

                result.Add(newGroup.Distinct().ToList());
            }

            return result;
        }
    }
}
