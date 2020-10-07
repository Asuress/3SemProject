using System;
using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Components
{
    public class PositionChangedEventArgs : EventArgs
    {
        public PositionChangedEventArgs(Point oldPosition, Point newPosition)
        {
            OldPosition = oldPosition;
            NewPosition = newPosition;
        }
        public Point OldPosition { get; }
        public Point NewPosition { get; }
    }
}