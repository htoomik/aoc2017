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
            var data = new Dictionary<Tuple<int, int>, int>();
            data.Add(new Tuple<int, int>(0, 0), 1);
            data.Add(new Tuple<int, int>(1, 0), 2);
            data.Add(new Tuple<int, int>(1, 1), 3);
            data.Add(new Tuple<int, int>(0, 1), 4);
            data.Add(new Tuple<int, int>(-1, 1), 5);

            var cursor = new Cursor
            {
                X = -1,
                Y = 1,
                Direction = Direction.Down
            };
            for (var i = 6; i <= value; i++)
            {
                Move(data, cursor);
                //Console.WriteLine($"Value {i} is at ({cursor.X}, {cursor.Y})");
                data.Add(new Tuple<int, int>(cursor.X, cursor.Y), i);
            }
            return Math.Abs(cursor.X) + Math.Abs(cursor.Y);
        }


        private static void Move(Dictionary<Tuple<int, int>, int> grid, Cursor cursor)
        {
            var lookAtDirection = cursor.GetTurnDirection();
            var neighborCoordinates = GetNeighborCoordinates(cursor.X, cursor.Y, lookAtDirection);
            var hasNeighbor = grid.ContainsKey(neighborCoordinates);
            var passedCorner = !hasNeighbor;

            if (passedCorner)
                cursor.Turn();
            cursor.Step();
        }


        private static Tuple<int, int> GetNeighborCoordinates(int x, int y, Direction direction)
        {
            var cursor = new Cursor { X = x, Y = y, Direction = direction };
            cursor.Step();
            return new Tuple<int, int>(cursor.X, cursor.Y);
        }


        private class Cursor
        {
            public Direction Direction;
            public int X;
            public int Y;

            public void Step()
            {
                switch (Direction)
                {
                    case Direction.Up: Y++; break;
                    case Direction.Down: Y--; break;
                    case Direction.Left: X--; break;
                    case Direction.Right: X++; break;
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

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
