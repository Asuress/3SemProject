using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Game.Source.Logic;
using WPF_Game.Source.Main;
using Point = WPF_Game.Source.Logic.Point;
using Size = WPF_Game.Source.Logic.Size;

namespace WPF_Game.Source.Main
{
    public class Enemy : GameObject
    {
        public Enemy(GameObject target)
            : base(new Ellipse(), new ImageBrush(new BitmapImage(
                    new Uri(@"C:\Users\Admin\source\repos\3SemProject\WPF Game\source\images\Enemy.png", UriKind.Absolute))),
                    new Point(), new Size(), "Enemy")
        {
            Target = target;
        }
        public GameObject Target { get; set; }
        private double _Speed = 0.7;
        protected override void Update()
        {
            Logic.Vector direction = 
                new Logic.Vector(Target.Transform.Position.X - Transform.Position.X, Target.Transform.Position.Y - Transform.Position.Y);
            direction.Normalize();
            Point pos = Transform.Position;
            Transform.Position = new Point(pos.X + _Speed * direction.X, pos.Y + _Speed * direction.Y);
        }
    }
}
