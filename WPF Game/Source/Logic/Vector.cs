using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;

namespace WPF_Game.Source.Logic
{
    public class Vector
    {
        public Vector(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
            _Length = Math.Sqrt(X * X + Y * Y);
        }
        public Vector(Vector v) : this(v.X, v.Y) { }

        public double X { get; private set; }
        public double Y { get; private set; }
        private double _Length;
        public double Length
        {
            get
            {
                _Length = Math.Sqrt(X * X + Y * Y);
                return _Length;
            }
        }

        public void Normalize()
        {
            if (Length != 0)
            {
                X /= _Length;
                Y /= _Length;
            }
        }
        public Vector GetNormalVector()
        {
            if (Length != 0)
                return new Vector(X / Length, Y / Length);
            else
                return new Vector(0, 0);
        }
        public static double ScalarMul(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public override bool Equals(object o)
        {
            if (o is Vector)
            {
                return Equals(this, o);
            }
            return false;
        }
        public static bool Equals(Vector v1, Vector v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }
        public static Vector operator +(Vector v) => v;
        public static Vector operator -(Vector v) => new Vector(-v.X, -v.Y);
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static Vector operator *(Vector v1, double scalar)
        {
            return new Vector(v1.X * scalar, v1.Y * scalar);
        }
        public static Vector operator /(Vector v1, double scalar)
        {
            return new Vector(v1.X / scalar, v1.Y / scalar);
        }
        public static bool operator !=(Vector v1, Vector v2) => !(v1.X == v2.X && v1.Y == v2.Y);
        public static bool operator ==(Vector v1, Vector v2) => (v1.X == v2.X && v1.Y == v2.Y);
    }
}