using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Game.Source.Components
{
    class Transform : IComponent
    {
        public Transform(Point pos, Size size)
        {
            Position = pos;
            Size = size;
        }
        public Transform(double x, double y, double width, double height) 
            : this(new Point(x, y), new Size(width, height))
        {

        }
        public Point Position { get; set; }
        public Size Size { get; set; }
    }
}
