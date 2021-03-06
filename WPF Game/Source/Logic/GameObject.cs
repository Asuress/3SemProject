﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Game.Source.Components;
using WPF_Game.Source.Main;
using WPF_Game.Source.Physics;
using Transform = WPF_Game.Source.Components.Transform;

namespace WPF_Game.Source.Logic
{
    public class GameObject : GameManager
    {
        public GameObject(Shape shape, ImageBrush img, Point pos, Size size, string tag = "")
        {
            Shape = shape;
            Transform = new Transform(this);
            //Transform.PositionChanged += Transform_PositionChanged;
            Transform.SizeChanged += Transform_SizeChanged;
            Transform.Position = pos;
            Transform.Size = size;
            ImageBrush = img;
            Shape.Fill = ImageBrush;
            Tag = tag;
            components = new LinkedList<IComponent>();
        }
        public string Tag { get; set; }
        LinkedList<IComponent> components;
        public Shape Shape { get; set; }
        public ImageBrush ImageBrush { get; set; }
        public Transform Transform { get; set; }
        public T GetComponent<T>() where T: class
        {
            foreach (var component in components)
            {
                if(component is T)
                {
                    return (T)component;
                }
            }
            return null;
        }
        public bool AddComponent(IComponent component)
        {
            foreach (var cmp in components)
            {
                if(cmp.GetType() == component.GetType())
                {
                    return false;
                }
            }
            components.AddLast(component);
            return true;
        }

        protected void Transform_SizeChanged(object sender, Transform.SizeChangedEventArgs e)
        {
            if (e.NewSize != null)
            {
                Shape.Width = e.NewSize.Width;
                Shape.Height = e.NewSize.Height;
            }
        }
        //protected void Transform_PositionChanged(object sender, Transform.PositionChangedEventArgs e)
        //{
        //    if (e.NewPosition != null)
        //    {
        //        Canvas.SetLeft(Shape, e.NewPosition.X);
        //        Canvas.SetTop(Shape, e.NewPosition.Y);
        //    }
        //}
    }
}
