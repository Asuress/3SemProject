using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using WPF_Game.Source.Components;
using WPF_Game.Source.Graphics;
using WPF_Game.Source.Logic;
using WPF_Game.Source.Main;
using Size = WPF_Game.Source.Logic.Size;

namespace WPF_Game.Source.Physics
{
    public class BoxCollider : Game
    {
        public class ColliderEventArgs
        {
            public ColliderEventArgs(GameObject collider) { }
        }

        public delegate void ColliderEventHandler(object sender, ColliderEventArgs e);

        public event ColliderEventHandler OnCollisionEnter = delegate { };
        public event ColliderEventHandler OnCollisionExit = delegate { };
        public event ColliderEventHandler OnCollisionStay = delegate { };
        public BoxCollider(GameObject parent, Scene scene)
        {
            Parent = parent;
            Size = parent.Transform.Size;
            _Scene = scene;
        }
        public BoxCollider(Size size, GameObject parent, Scene scene)
        {
            Parent = parent;
            Size = size;
            _Scene = scene;
        }
        
        public Size Size { get; set; }

        bool IsStay = false;
        GameObject Parent;
        Scene _Scene;

        protected override void Update()
        {
            LinkedList<GameObject> intersectsWith = new LinkedList<GameObject>();
            foreach (var go in _Scene.GameObjects)
            {
                if (IntersectWith(go) && go != Parent)
                {
                    intersectsWith.AddLast(go);
                    foreach (var intersect in intersectsWith)
                    {
                        if (IsStay && intersect == go)
                        {
                            MessageBox.Show("OnCollisionStay");
                            //OnCollisionStay
                        }
                        else
                        {
                            IsStay = true;
                            MessageBox.Show("OnCollisionEnter");
                            //OnCollisionEnter
                        }
                    }
                }
                else if(!IntersectWith(go) && go != Parent)
                {
                    foreach (var intersect in intersectsWith)
                    {
                        if (IsStay && intersect == go)
                        {
                            IsStay = false;
                            MessageBox.Show("OnCollisionExit");
                            //OnCollisionExit
                        }
                    }
                }
            }
        }
        protected override void LateUpdate()
        {

        }
        private bool IntersectWith(GameObject gameObject)
        {
            if (Math.Abs(Parent.Transform.Position.X - gameObject.Transform.Position.X) <= (Parent.Transform.Size.Width + gameObject.Transform.Size.Width) / 2 &&
               Math.Abs(Parent.Transform.Position.Y - gameObject.Transform.Position.Y) <= (Parent.Transform.Size.Height + gameObject.Transform.Size.Height) / 2)
            {
                return true;
            }
            return false;
        }
    }
}
