using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF_Game.Source.Components;
using WPF_Game.Source.Graphics;
using WPF_Game.Source.Physics;

namespace WPF_Game.Source.Logic
{
    class GameObject
    {
        public GameObject(Shape shape, ImageBrush imgBrush, Point position, Size size, string tag = null)
        {
            Shape = shape;
            ImageBrush = imgBrush;
            Components.Transform.PositionChanged += Transform_PositionChanged;
            Components.Transform.SizeChanged += Transform_SizeChanged;
            Transform = new Components.Transform(position, size);
            Shape.Fill = ImageBrush;
            Tag = tag;
            CompositionTarget.Rendering += GameLoop;
        }
        public Shape Shape { get; private set; }
        public ImageBrush ImageBrush { get; set; }
        public string Tag { get; set; }
        public Components.Transform Transform { get; }
        private void GameLoop(object sender, EventArgs e)
        {
            Update();
            LateUpdate();
        }
        protected virtual void Update() 
        { 

        }
        protected virtual void LateUpdate() 
        {

        }
        public bool IntersectWith(GameObject gameObject)
        {
            if(Math.Abs(Transform.Position.X - gameObject.Transform.Position.X) <= 
               Math.Max(Transform.Size.Width, gameObject.Transform.Size.Width) &&
               Math.Abs(Transform.Position.Y - gameObject.Transform.Position.Y) <= 
               Math.Max(Transform.Size.Height, gameObject.Transform.Size.Height))
            {
                return true;
            }
            return false;
        }
        private void Transform_SizeChanged(object sender, Components.SizeChangedEventArgs e)
        {
            Shape.Width = e.NewSize.Width;
            Shape.Height = e.NewSize.Height;
        }
        private void Transform_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            Canvas.SetLeft(Shape, e.NewPosition.X);
            Canvas.SetTop(Shape, e.NewPosition.Y);
        }
    }
}
