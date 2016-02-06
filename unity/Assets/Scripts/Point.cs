using System;

namespace MrStarBase
{
    public class Point : IEquatable<Point>
    {
        readonly int x;
        readonly int y;

        public int X { get { return x; } }

        public int Y { get { return y; } }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Distance(Point other)
        {
            return Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y);
        }

        public bool IsNext(Point other)
        {
            return this.Distance(other) == 1;
        }

        public bool Equals(Point other)
        {
            if (other == null)
                return false;

            if (this.X == other.X && this.Y == other.y)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Point other = obj as Point;
            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==(Point lhs, Point rhs)
        {
            if ((object)lhs == null || ((object)rhs) == null)
                return Object.Equals(lhs, rhs);

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Point lhs, Point rhs)
        {
            if (lhs == null || rhs == null)
                return !Object.Equals(lhs, rhs);

            return !(lhs.Equals(rhs));
        }
    }
}