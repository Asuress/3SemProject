﻿using System;
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
            //Parent = parent;
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
                Sides side;
                if (IntersectWith(go, out side) && go != parent)
                {
                    intersectsWith.AddLast(go);
                    foreach (var intersect in intersectsWith)
                    {
                        if (isStay && intersect == go)
                        {
                            InvokeOnCollisionStay(go.GetComponent<Collider>(), side);
                        }
                        else
                        {
                            isStay = true;
                            InvokeOnCollisionEnter(go.GetComponent<Collider>(), side);
                        }
                    }
                }
                else if(!IntersectWith(go, out side) && go != parent)
                {
                    foreach (var intersect in intersectsWith)
                    {
                        if (isStay && intersect == go)
                        {
                            isStay = false;
                            InvokeOnCollisionExit(go.GetComponent<Collider>(), side);
                        }
                    }
                }
            }
        }

        private bool IntersectWith(GameObject gameObject, out Sides side)
        {
            if (Math.Abs(parent.Transform.Position.X - gameObject.Transform.Position.X) <= (parent.Transform.Size.Width + gameObject.Transform.Size.Width) / 2 &&
               Math.Abs(parent.Transform.Position.Y - gameObject.Transform.Position.Y) <= (parent.Transform.Size.Height + gameObject.Transform.Size.Height) / 2)
            {
                side = default;
                if (parent.Transform.Position.X - gameObject.Transform.Position.X >= 0)
                    side = Sides.West;
                else if (parent.Transform.Position.X - gameObject.Transform.Position.X <= 0)
                    side = Sides.East;
                else if (parent.Transform.Position.Y - gameObject.Transform.Position.Y > 0)
                    side = Sides.North;
                else if (parent.Transform.Position.Y - gameObject.Transform.Position.Y > 0)
                    side = Sides.South;
                return true;
            }
            side = default;
            return false;
        }
    }
}
