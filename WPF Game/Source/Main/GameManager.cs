using System;
using System.Windows.Media;

namespace WPF_Game.Source.Main
{
    public abstract class GameManager
    {
        public GameManager()
        {
            gameTimer = new System.Windows.Threading.DispatcherTimer();
            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromSeconds(1/FPS);
            gameTimer.Start();
            //CompositionTarget.Rendering += GameLoop;
        }

        System.Windows.Threading.DispatcherTimer gameTimer;
        public static double FPS = 100;

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
