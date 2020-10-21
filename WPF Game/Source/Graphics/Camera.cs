using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Graphics
{
    class Camera
    {
        public Camera(Scene scene, Point position, GameObject parent = null)
        {
            MainScene = scene;
            Position = position;
            Parent = parent;
        }
        public Scene MainScene { get; set; }
        public Point Position { get; set; }
        public GameObject Parent { get; private set; }
    }
}
