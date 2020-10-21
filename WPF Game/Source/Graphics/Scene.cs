using System;
using System.Collections.Generic;
using System.Windows.Controls;
using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Graphics
{
    public class Scene : Canvas
    {
        public class SceneChangedEventArgs
        {
            public SceneChangedEventArgs(LinkedList<GameObject> oldScene, LinkedList<GameObject> newScene)
            {
                OldScene = oldScene;
                NewScene = newScene;
            }
            public LinkedList<GameObject> OldScene { get; }
            public LinkedList<GameObject> NewScene { get; }
        }
        public delegate void SceneChangedHandler(object sender, SceneChangedEventArgs e);
        public event SceneChangedHandler SceneChanged = delegate { };
        public static Scene GetInstance()
        {
            if (Instances == null)
                Instances = new Scene();
            return Instances;            
        }
        static Scene Instances;
        Scene()
        {
            GameObjects = new LinkedList<GameObject>();
        }
        public LinkedList<GameObject> GameObjects { get; }
        public void AddGameObject(GameObject gameObject)
        {
            GameObjects?.AddLast(gameObject ?? throw new Exception("null game object"));
            Children.Add(gameObject.Shape);
        }
        public void RemoveGameObject(GameObject go)
        {
            GameObjects.Remove(go);
        }
        public bool ContainsGameObject(GameObject gameObject)
        {
            return GameObjects.Contains(gameObject);
        }
    }
}
