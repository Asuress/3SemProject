using System;
using System.Collections.Generic;
using WPF_Game.Source.Logic;
using WPF_Game.Source.Main;
using WPF_Game.Source.Physics;
using Vector = System.Windows.Vector;

namespace WPF_Game.Source.Components
{
    class Rigidbody : GameManager, IComponent
    {
        public enum Mode
        {
            Force,
            Impulse
        }
        public Rigidbody(GameObject parent)
        {
            Parent = parent;
            Mass = 1;
            Friction = 1;
            //forces = new LinkedList<Vector>();
            summaryForces = new Vector(0, 0);
            acceleration = new Vector(0, 0);
            Velocity = new Vector(0, 0);
            direction = new Vector(0, 0);
            frictionValue = Friction * Mass * g;
            frictionForce = new Vector(0, 0);
            //collider = Parent.GetComponent<Collider>();
        }

        public double Friction { get; set; }
        public double Mass { get; set; }
        const double g = 9.81;
        //Collider collider;
        GameObject Parent { get; set; }
        //LinkedList<Vector> forces;
        public Vector direction;
        public Vector summaryForces;
        public Vector additionalForce;
        public Vector Velocity;
        public Vector acceleration;
        public Vector frictionForce;

        private double frictionValue;
        double dAcceleration = 0;
        double speed = 0;

        public void AddForce(Vector value, Mode mode)
        {
            switch (mode)
            {
                case Mode.Force:
                    additionalForce = value;
                    Velocity += (value * Time.DeltaTime) / Mass;
                    break;
                case Mode.Impulse:
                    Velocity += value;
                    break;
                default:
                    break;
            }
        }

        protected override void EarlyUpdate()
        {
            direction.X = Velocity.X;
            direction.Y = Velocity.Y;

            if(direction.LengthSquared != 0)
            {
                direction.Normalize();
                frictionForce = frictionValue * -direction;
            }

            if (additionalForce.LengthSquared != 0)
            {
                acceleration = additionalForce / Mass;
            }
            else
            {
                acceleration = frictionForce * direction * direction / Mass;
            }

            Velocity += acceleration * Time.DeltaTime;

            if (Velocity.LengthSquared < 0.001)
            {
                Velocity.X = 0;
                Velocity.Y = 0;
            }

            Parent.Transform.Position = new Point(
                Parent.Transform.Position.X + Velocity.X,
                Parent.Transform.Position.Y + Velocity.Y
                );

            additionalForce *= 0;
        }
    }
}
