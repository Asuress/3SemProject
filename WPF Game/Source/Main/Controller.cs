using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WPF_Game.Source.Components;
using WPF_Game.Source.Graphics;
using WPF_Game.Source.Logic;
using Point = WPF_Game.Source.Logic.Point;
using Vector = System.Windows.Vector;


namespace WPF_Game.Source.Main
{
    public class Controller : GameManager, IComponent
    {
        public Controller(GameObject _parent, double _speed)
        {
            parent = _parent;
            speed = _speed;
            rb = parent.GetComponent<Rigidbody>();
        }

        Rigidbody rb;
        double speed;
        GameObject parent;

        protected override void Update()
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                rb.AddForce(new Vector(0, -speed), Rigidbody.Mode.Force);
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                rb.AddForce(new Vector(0, speed), Rigidbody.Mode.Force);
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                rb.AddForce(new Vector(-speed, 0), Rigidbody.Mode.Force);
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                rb.AddForce(new Vector(speed, 0), Rigidbody.Mode.Force);
            }
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                
            }
        }
    }
}
