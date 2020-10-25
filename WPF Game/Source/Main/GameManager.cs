using System;
using System.Windows.Media;

namespace WPF_Game.Source.Main
{
    public abstract class GameManager
    {
        public GameManager()
        {
            CompositionTarget.Rendering += GameLoop;
        }
        protected void GameLoop(object sender, EventArgs e)
        {
            EarlyUpdate();
            Update();
            LateUpdate();
        }
        protected virtual void EarlyUpdate() { }
        protected virtual void Update() { }
        protected virtual void LateUpdate() { }
    }
}
