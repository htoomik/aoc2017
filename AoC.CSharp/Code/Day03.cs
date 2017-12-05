using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Code
{
    class Day03
    {
        public static int Solve(int value)
        {
            var data = new Dictionary<XY, int>();
            data.Add(new XY(0, 0), 1);
            data.Add(new XY(1, 0), 2);
            data.Add(new XY(1, 1), 3);
            data.Add(new XY(0, 1), 4);
            data.Add(new XY(-1, 1), 5);

            var cursor = new Cursor
            {
                XY = new XY(-1, 1),
                Direction = Direction.Down
            };
            for (var i = 6; i <= value; i++)
            {
                Move(data, cursor);
                //Console.WriteLine($"Value {i} is at ({cursor.X}, {cursor.Y})");
                data.Add(new XY(cursor.XY), i);
            }
            return Math.Abs(cursor.XY.X) + Math.Abs(cursor.XY.Y);
        }


        public static int Solve2(int value)
        {
            var data = new Dictionary<XY, int>();
            data.Add(new XY(0, 0), 1);
            data.Add(new XY(1, 0), 1);
            data.Add(new XY(1, 1), 2);
            data.Add(new XY(0, 1), 4);
            data.Add(new XY(-1, 1), 5);

            var cursor = new Cursor
            {
                XY = new XY(-1, 1),
                Direction = Direction.Down
            };
            while (true)
            {
                Move(data, cursor);
                var valueToStore = SumOfNeighbors(data, cursor.XY);
                data.Add(new XY(cursor.XY), valueToStore);
                if (valueToStore >= value)
                    return valueToStore;
            }
        }


        private static void Move(Dictionary<XY, int> grid, Cursor cursor)
        {
            var lookAtDirection = cursor.GetTurnDirection();
            var neighborCoordinates = GetNeighborCoordinates(cursor.XY, lookAtDirection);
            var hasNeighbor = grid.ContainsKey(neighborCoordinates);
            var passedCorner = !hasNeighbor;

            if (passedCorner)
                cursor.Turn();
            cursor.Step();
        }


        private static XY GetNeighborCoordinates(XY xy, Direction direction)
        {
            var cursor = new Cursor { XY = xy, Direction = direction };
            cursor.Step();
            return cursor.XY;
        }


        private static int SumOfNeighbors(Dictionary<XY, int> grid, XY target)
        {
            var sum = 0;
            sum += GetNeighborValue(grid, target, -1, -1);
            sum += GetNeighborValue(grid, target, -1, 0);
            sum += GetNeighborValue(grid, target, -1, 1);
            sum += GetNeighborValue(grid, target, 0, -1);
            sum += GetNeighborValue(grid, target, 0, 1);
            sum += GetNeighborValue(grid, target, 1, -1);
            sum += GetNeighborValue(grid, target, 1, 0);
            sum += GetNeighborValue(grid, target, 1, 1);
            return sum;
        }


        private static int GetNeighborValue(Dictionary<XY, int> grid, XY start, int xOffset, int yOffset)
        {
            var key = new XY(start.X + xOffset, start.Y + yOffset);
            if (grid.ContainsKey(key))
                return grid[key];
            return 0;
        }
        
        private class Cursor
        {
            public Direction Direction;
            public XY XY;

            public void Step()
            {
                switch (Direction)
                {
                    case Direction.Up: XY.Y++; break;
                    case Direction.Down: XY.Y--; break;
                    case Direction.Left: XY.X--; break;
                    case Direction.Right: XY.X++; break;
                    default: throw new Exception();
                }
            }


            public void Turn()
            {
                Direction = GetTurnDirection();
            }


            public Direction GetTurnDirection()
            {
                switch (Direction)
                {
                    case Direction.Up: return Direction.Left;
                    case Direction.Down: return Direction.Right;
                    case Direction.Left: return Direction.Down;
                    case Direction.Right: return Direction.Up;
                    default: throw new Exception();
                }
            }
        }


        private struct XY
        {
            public int X;
            public int Y;

            public XY(int x, int y)
            {
                X = x;
                Y = y;
            }


            public XY(XY xy)
            {
                X = xy.X;
                Y = xy.Y;
            }
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
