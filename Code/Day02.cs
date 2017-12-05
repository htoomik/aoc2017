using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Code
{
    public class Day02
    {
        public static int Solve(IEnumerable<IEnumerable<int>> indata)
        {
            return indata.Select(row => row.Max() - row.Min()).Sum();
        }


        public static int Solve2(IEnumerable<IEnumerable<int>> indata)
        {
            return indata.Select(row => FindPair(row.ToList())).Sum();
        }


        private static int FindPair(List<int> indata)
        {
            for (int i = 0; i < indata.Count(); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var ii = indata[i];
                    var jj = indata[j];
                    if (ii % jj == 0)
                        return ii / jj;
                    if (jj % ii == 0)
                        return jj / ii;
                }
            }
            throw new Exception("No pair found in " + string.Join(", ", indata));
        }
    }
}
