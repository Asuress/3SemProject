using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Game.Source.Logic
{
    public class Size
    {
        public Size(double width = 0, double height = 0)
        {
            Width = width;
            Height = height;
        }
        private double _Width;
        private double _Height;
        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value < 0 ? 0 : value;
            }
        }
        public double Height
        {
            get { return _Height; }
            set
            {
                _Height = value < 0 ? 0 : value;
            }
        }

        public Vector2 SizeToVector()
        {
            return new Vector2(Width, Height);
        }
        public static Vector2 SizeToVector(Size size)
        {
            return new Vector2(size.Width, size.Height);
        }
        public bool Equals(Size size1, Size size2) => size1.Width == size2.Width && size1.Height == size2.Height;
        public bool Equals(Size size) => size?.Width == Width && size?.Height == Height;
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Size size1, Size size2) => size1.Equals(size2);
        public static bool operator !=(Size size1, Size size2) => !size1.Equals(size2);
    }
}