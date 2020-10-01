using System;
using System.Collections.Generic;
using System.Text;
using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Graphics
{
    class Scene
    {
        public static Scene GetInstance()
        {
            if (Instances == null)
                Instances = new Scene();
            return Instances;            
        }
        static Scene Instances;
        Scene()
        {
            
        }
        List<GameObject> GameObjects;
    }
}
