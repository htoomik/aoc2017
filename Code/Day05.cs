using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Code
{
    class Day05
    {
        public static int Solve(IEnumerable<int> indata)
        {
            var a = indata.ToArray();
            var i = 0;
            var steps = 0;
            while (i >= 0 && i < a.Length)
            {
                steps++;
                var jump = a[i];
                a[i]++;
                i += jump;
            }
            return steps;
        }


        public static int Solve2(IEnumerable<int> indata)
        {
            var a = indata.ToArray();
            var i = 0;
            var steps = 0;
            while (i >= 0 && i < a.Length)
            {
                steps++;
                var jump = a[i];
                if(jump >= 3)
                    a[i]--;
                else
                    a[i]++;
                i += jump;
            }
            return steps;
        }
    }
}
