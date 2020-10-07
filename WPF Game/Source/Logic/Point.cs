using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Game.Source.Logic
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double _x = 0, double _y = 0)
        {
            X = _x;
            Y = _y;
        }
        public Point(Point _p)
        {
            X = _p.X;
            Y = _p.Y;
        }
        public override bool Equals(object any)
        {
            if (any is Point)
            {
                return Equals(this, any);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool Equals(Point p1, Point p2)
        {
            if (p1.X == p2.X && p1.Y == p2.Y)
            {
                return true;
            }
            return false;
        }
        public Vector2 Subtract(Point end)
        {
            return new Vector2(end.X - this.X, end.Y - this.Y);
        }
        public void Move(double _x, double _y)
        {
            X += _x;
            Y += _y;

        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static bool operator !=(Point p1, Point p2) => !(p1.X == p1.X && p1.Y == p2.Y);
        public static bool operator ==(Point p1, Point p2) => (p1.X == p2.X && p1.Y == p2.Y);
    }
}