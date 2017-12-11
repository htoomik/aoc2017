using System;

namespace AoC.Code
{
    public class Day11
    {
        public static Tuple<int, int> Solve(string indata)
        {
            var steps = indata.Split(',');

            int totalX = 0;
            int totalY = 0;
            int maxDistance = 0;

            foreach (var step in steps)
            {
                var move = Navigate(step);
                totalX += move.X;
                totalY += move.Y;
                var distance = GetDistance(totalX, totalY);
                maxDistance = Math.Max(maxDistance, distance);
            }
            
            var finalDistance = GetDistance(totalX, totalY);
            return new Tuple<int, int>(finalDistance, maxDistance);
        }


        private static XY Navigate(string step)
        {
            switch (step)
            {
                case "n": return new XY(0, 2);
                case "s": return new XY(0, -2);
                case "ne": return new XY(1, 1);
                case "se": return new XY(1, -1);
                case "nw": return new XY(-1, 1);
                case "sw": return new XY(-1, -1);
            }
            return new XY(0, 0);
        }


        private static int GetDistance(int x, int y)
        {
            var xSteps = Math.Abs(x);
            var ySteps = Math.Abs(y);

            // each step in the grid can be either one x unit and one y unit, or two y units.
            return xSteps + Math.Abs(ySteps - xSteps) / 2;
        }

        private class XY
        {
            public int X;
            public int Y;


            public XY(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
