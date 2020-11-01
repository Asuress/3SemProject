using System;
using System.Collections.Generic;
using WPF_Game.Source.Graphics;
using WPF_Game.Source.Logic;
using Size = WPF_Game.Source.Logic.Size;

namespace WPF_Game.Source.Physics
{
    public class BoxCollider : Collider
    {

        public BoxCollider(GameObject parent, Scene scene) : base(parent)
        {
            Size = parent.Transform.Size;
            this.scene = scene;
        }
        public BoxCollider(GameObject parent, Scene scene, Size size) : base(parent)
        {
            Size = size;
            this.scene = scene;
        }
        
        public Size Size { get; set; }

        bool isStay = false;
        Scene scene;

        protected override void EarlyUpdate()
        {
            LinkedList<GameObject> intersectsWith = new LinkedList<GameObject>();
            foreach (var go in scene.GameObjects)
            {
                System.Windows.Vector normal;
                if (IntersectWith(go, out normal) && go != parent)
                {
                    intersectsWith.AddLast(go);
                    foreach (var intersect in intersectsWith)
                    {
                        if (isStay && intersect == go)
                        {
                            InvokeOnCollisionStay(go.GetComponent<Collider>(), normal);
                        }
                        else
                        {
                            isStay = true;
                            InvokeOnCollisionEnter(go.GetComponent<Collider>(), normal);
                        }
                    }
                }
                else if(!IntersectWith(go, out normal) && go != parent)
                {
                    foreach (var intersect in intersectsWith)
                    {
                        if (isStay && intersect == go)
                        {
                            isStay = false;
                            InvokeOnCollisionExit(go.GetComponent<Collider>(), normal);
                        }
                    }
                }
            }
        }

        private bool IntersectWith(GameObject gameObject, out System.Windows.Vector normal)
        {
            if (Math.Abs(parent.Transform.Position.X - gameObject.Transform.Position.X) <= (parent.Transform.Size.Width + gameObject.Transform.Size.Width) / 2 &&
               Math.Abs(parent.Transform.Position.Y - gameObject.Transform.Position.Y) <= (parent.Transform.Size.Height + gameObject.Transform.Size.Height) / 2)
            {
                normal = default;
                if (parent.Transform.Position.X - gameObject.Transform.Position.X >= 0)
                    normal = new System.Windows.Vector(-1, 0); //West
                else if (parent.Transform.Position.X - gameObject.Transform.Position.X <= 0)
                    normal = new System.Windows.Vector(1, 0); //East
                else if (parent.Transform.Position.Y - gameObject.Transform.Position.Y > 0)
                    normal = new System.Windows.Vector(0, 1); //North
                else if (parent.Transform.Position.Y - gameObject.Transform.Position.Y > 0)
                    normal = new System.Windows.Vector(0, -1); //South
                return true;
            }
            normal = default;
            return false;
        }
    }
}
