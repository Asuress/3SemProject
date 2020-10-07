using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Components
{
    class Transform : IComponent
    {
        public delegate void PositionChangedEventHandler(object sender, PositionChangedEventArgs e);
        public delegate void SizeChangedEventHandler(object sender, SizeChangedEventArgs e);
        public static event SizeChangedEventHandler SizeChanged = delegate { };
        public static event PositionChangedEventHandler PositionChanged = delegate { };
        public Transform(Point pos, Size size)
        {
            Position = pos;
            Size = size;
        }
        public Transform(double x, double y, double width, double height) 
            : this(new Point(x, y), new Size(width, height))
        {

        }
        private Point _Position;
        public Point Position 
        {
            get { return _Position; } 
            set 
            {
                PositionChangedEventHandler handler = PositionChanged;
                PositionChanged(this, new PositionChangedEventArgs(_Position, new Point(value)));
                _Position = value;
            } 
        }
        private Size _Size;
        public Size Size 
        {
            get{ return _Size; }
            set
            {
                SizeChanged(this, new SizeChangedEventArgs(_Size, value));
                _Size = value;
            }
        }

        
    }
}
