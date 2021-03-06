﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Game.Source.Logic
{
    public class Point
    {
        public class PointChangedEventArgs
        {
            public PointChangedEventArgs(double oldX, double oldY, double newX, double newY) 
            {
                OldX = oldX;
                OldY = oldY;
                NewX = newX;
                NewY = newY;
            }
            public double OldX { get; private set; }
            public double OldY { get; private set; }
            public double NewX { get; private set; }
            public double NewY { get; private set; }
        }

        public delegate void PointChangedHandler(object sender, PointChangedEventArgs e);

        public event PointChangedHandler PointChanged = delegate { };

        public Point(double _x = 0, double _y = 0)
        {
            _X = _x;
            _Y = _y;
        }
        public Point(Point _p)
        {
            X = _p.X;
            Y = _p.Y;
        }
        private double _X;
        public double X
        {
            get
            {
                return _X;
            }
            set
            {
                var oldPoint = this;
                _X = value;
                PointChanged(this, new PointChangedEventArgs(oldPoint.X, oldPoint.Y, X, Y));
            }
        }
        private double _Y;
        public double Y
        {
            get
            {
                return _Y;
            }
            set
            {
                var oldPoint = this;
                _Y = value;
                PointChanged(this, new PointChangedEventArgs(oldPoint.X, oldPoint.Y, X, Y));
            }
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
        public Vector Subtract(Point end)
        {
            return new Vector(end.X - this.X, end.Y - this.Y);
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
        public static bool operator !=(Point p1, Point p2) => !(p1?.X == p2?.X && p1?.Y == p2?.Y);
        public static bool operator ==(Point p1, Point p2) => (p1?.X == p2?.X && p1?.Y == p2?.Y);
    }
}