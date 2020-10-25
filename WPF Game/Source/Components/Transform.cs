using System;
using System.Windows.Media;
using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Components
{
    public class Transform : IComponent
    {
        public class PositionChangedEventArgs
        {
            public PositionChangedEventArgs(Point oldPosition, Point newPosition)
            {
                OldPosition = oldPosition;
                NewPosition = newPosition;
            }
            public Point OldPosition { get; }
            public Point NewPosition { get; }
        }
        public class SizeChangedEventArgs
        {
            public SizeChangedEventArgs(Size oldSize, Size newSize)
            {
                OldSize = oldSize;
                NewSize = newSize;
            }
            public Size OldSize { get; }
            public Size NewSize { get; }
        }
        
        public delegate void PositionChangedEventHandler(object sender, PositionChangedEventArgs e);
        public delegate void SizeChangedEventHandler(object sender, SizeChangedEventArgs e);

        public event SizeChangedEventHandler SizeChanged = delegate { };
        public event PositionChangedEventHandler PositionChanged = delegate { };

        public Transform()
        {
            _Position = new Point();
            _Size = new Size();
        }
        public Transform(Point pos, Size size)
        {
            Position = pos;
            Size = size;
        }
        public Transform(double x, double y, double width, double height) 
            : this(new Point(x, y), new Size(width, height))
        {
            _Position.PointChanged += Position_PointChanged;
        }

        private void Position_PointChanged(object sender, Point.PointChangedEventArgs e)
        {
            PositionChanged(this, new PositionChangedEventArgs(new Point(e.OldX, e.OldY), new Point(e.NewX, e.NewY)));
        }

        private Point _Position;
        public Point Position 
        {
            get { return _Position; } 
            set 
            {
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
        public Point ObjectCenter
        {
            get
            {
                return new Point(Position.X + Size.Width / 2, Position.Y + Size.Height / 2);
            }
        }
        public RotateTransform RotateTransform { get; set; }        
    }
}
