using WPF_Game.Source.Components;
using WPF_Game.Source.Logic;
using WPF_Game.Source.Main;

namespace WPF_Game.Source.Physics
{
    public abstract class Collider : GameManager, IComponent
    {
        public enum Sides { Default = 0, North, West, South, East }
        public class ColliderEventArgs
        {
            public ColliderEventArgs(Collider collider, Sides side) 
            {
                Side = side;
                Collider = collider;
            }
            public Collider Collider { get; }
            public Sides Side { get; }
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

        protected void InvokeOnCollisionEnter(Collider collider, Sides side)
        {
            OnCollisionEnter(new ColliderEventArgs(collider, side));
        }
        protected void InvokeOnCollisionStay(Collider collider, Sides side)
        {
            OnCollisionStay(new ColliderEventArgs(collider, side));
        }
        protected void InvokeOnCollisionExit(Collider collider, Sides side)
        {
            OnCollisionExit(new ColliderEventArgs(collider, side));
        }
    }
}
