using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_Game.Pages
{
    public partial class Game : Page
    {
        public static Game GetInstance()
        {
            if (Instances != null)
            {
                return Instances;
            }
            Instances = new Game();
            return Instances;
        }
        static Game Instances;
        private Game()
        {
            InitializeComponent();
            IsGameStarted = false;
        }

        DispatcherTimer GameTimer = new DispatcherTimer();
        private bool IsGameStarted;
        private double Speed = 10;

        public void Start()
        {
            IsGameStarted = true;
            GameTimer.Tick += GameLoop;
            GameTimer.Start();
        }
        public void Stop()
        {
            IsGameStarted = false;
            GameTimer.Stop();
            GameTimer.Tick -= GameLoop;
        }
        protected void GameLoop(object sender, EventArgs e)
        {
            ForceUpdate();
            Update();
        }
        protected void Update()
        {
            
        }
        protected void ForceUpdate()
        {

        }
    }
}
