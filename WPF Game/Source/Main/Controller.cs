using System.Windows;
using System.Windows.Input;
using WPF_Game.Source.Components;
using WPF_Game.Source.Graphics;
using WPF_Game.Source.Logic;
using Point = WPF_Game.Source.Logic.Point;

namespace WPF_Game.Source.Main
{
    public class Controller : GameManager, IComponent
    {
        public Controller(GameObject _parent, double _speed)
        {
            parent = _parent;
            speed = _speed;
        }

        double speed;
        GameObject parent;

        protected override void Update()
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                parent.Transform.Position += new Point(0, -1 * speed);
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                parent.Transform.Position += new Point(0, speed);
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                parent.Transform.Position += new Point(-1 * speed, 0);
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                parent.Transform.Position += new Point(speed, 0);
            }
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MessageBox.Show("LMouse pressed");
            }
        }
    }
}
