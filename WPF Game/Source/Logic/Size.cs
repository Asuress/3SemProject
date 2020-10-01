using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.code.logic
{
    class Size
    {
        public Size(double width, double height)
        {
            Width = width;
            Height = height;
        }
        double Width
        {
            get { return Width; }
            set
            {
                if (value < 0)
                    Width = 0;
                else
                    Width = value;
            }
        }
        double Height
        {
            get { return Width; }
            set
            {
                if (value < 0)
                    Height = 0;
                else
                    Height = value;
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
        public bool Equals(Size size) => size.Width == Width && size.Height == Height;
        public override bool Equals(object o)
        {
            if (o is Size)
            {
                return Equals(this, o);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Size size1, Size size2) => size1.Equals(size2);
        public static bool operator !=(Size size1, Size size2) => !size1.Equals(size2);
    }
}