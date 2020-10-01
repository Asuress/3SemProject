using System;
using System.Collections.Generic;
using System.Text;
using WPF_Game.Source.Components;

namespace WPF_Game.Source.Logic
{
    class GameObject
    {
        GameObject()
        {

        }
        public List<IComponent> components { get; }
        public T GetComponent<T>()
        {
            foreach (var c in components)
            {
                if(c is T)
                {
                    return (T)c;
                }
            }
            return default;
        }
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }
    }
}
