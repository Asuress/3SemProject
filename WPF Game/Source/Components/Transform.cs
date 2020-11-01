using System;
using System.Windows.Controls;
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
        
        public delegate void PositionChangedEventHandler(GameObject sender, PositionChangedEventArgs e);
        public delegate void SizeChangedEventHandler(GameObject sender, SizeChangedEventArgs e);

        public event SizeChangedEventHandler SizeChanged = delegate { };
        public event PositionChangedEventHandler PositionChanged = delegate { };

        public Transform(GameObject parent)
        {
            Parent = parent;
            _Position = new Point();
            _Size = new Size();
        }
        public Transform(GameObject parent, Point pos, Size size) : this(parent)
        {
            Position = pos;
            Size = size;
        }
        public Transform(GameObject parent, double x, double y, double width, double height) 
            : this(parent, new Point(x, y), new Size(width, height))
        {
            _Position.PointChanged += Position_PointChanged;
        }

        readonly GameObject Parent;

        private void Position_PointChanged(object sender, Point.PointChangedEventArgs e)
        {
            PositionChanged(Parent, new PositionChangedEventArgs(new Point(e.OldX, e.OldY), new Point(e.NewX, e.NewY)));
        }

        private Point _Position;
        public Point Position 
        {
            get { return _Position; } 
            set 
            {
                var oldPos = _Position;
                _Position = value;
                PositionChanged(Parent, new PositionChangedEventArgs(oldPos, _Position));
            } 
        }
        private Size _Size;
        public Size Size 
        {
            get{ return _Size; }
            set
            {
                var oldSize = _Size;
                _Size = value;
                SizeChanged(Parent, new SizeChangedEventArgs(oldSize, _Size));
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
