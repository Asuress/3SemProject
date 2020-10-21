using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPF_Game.Source.Main
{
    public abstract class Game
    {
        public Game()
        {
            CompositionTarget.Rendering += GameLoop;
        }
        protected void GameLoop(object sender, EventArgs e)
        {
            Update();
            LateUpdate();
        }
        protected abstract void Update();
        protected abstract void LateUpdate();
    }
}
