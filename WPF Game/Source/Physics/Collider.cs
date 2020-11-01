using System.Windows;
using WPF_Game.Source.Components;
using WPF_Game.Source.Logic;
using WPF_Game.Source.Main;

namespace WPF_Game.Source.Physics
{
    public abstract class Collider : GameManager, IComponent
    {
        //public enum Sides { Default = 0, North, West, South, East }
        public class ColliderEventArgs
        {
            public ColliderEventArgs(Collider collider, System.Windows.Vector normal) 
            {
                Normal = normal;
                Collider = collider;
            }
            public Collider Collider { get; }
            public System.Windows.Vector Normal { get; }
        }

        public delegate void ColliderEventHandler(ColliderEventArgs colliderArgs);

        public virtual event ColliderEventHandler OnCollisionEnter = delegate { };
        public virtual event ColliderEventHandler OnCollisionExit = delegate { };
        public virtual event ColliderEventHandler OnCollisionStay = delegate { };

        protected Collider(GameObject parent)
        {
            this.parent = parent;
        }

        protected readonly GameObject parent;
        public System.Windows.Vector NormalCollision { get; set; }

        protected void InvokeOnCollisionEnter(Collider collider, System.Windows.Vector normal)
        {
            OnCollisionEnter(new ColliderEventArgs(collider, normal));
        }
        protected void InvokeOnCollisionStay(Collider collider, System.Windows.Vector normal)
        {
            OnCollisionStay(new ColliderEventArgs(collider, normal));
        }
        protected void InvokeOnCollisionExit(Collider collider, System.Windows.Vector normal)
        {
            OnCollisionExit(new ColliderEventArgs(collider, normal));
        }
    }
}
