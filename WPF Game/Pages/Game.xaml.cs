using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF_Game.Source.Graphics;
using WPF_Game.Source.Logic;

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
        }

        GameObject Player;
        private double RotateSpeed = 0.05;
        private RotateTransform Rotate;

        public void Start()
        {
            ImageBrush imgbr = new ImageBrush();
            imgbr.ImageSource = new BitmapImage(
                new Uri(@"C:\Users\Admin\source\repos\3SemProject\WPF Game\source\images\Player.jpg"));
            Player = new GameObject(new Rectangle(), imgbr, new Source.Logic.Point(10, 20), new Source.Logic.Size(100, 100));
            MainCanvas.Children.Add(Player.Shape);
            MainCanvas.Background = Brushes.Red;
            CompositionTarget.Rendering += GameLoop;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            Update();
            LateUpdate();
        }

        private void Update()
        {
            if (Rotate == null)
                Rotate = new RotateTransform(RotateSpeed);
            else
                Rotate = new RotateTransform(Rotate.Angle + RotateSpeed);
            Player.Shape.RenderTransform = Rotate;
        }

        private void LateUpdate()
        {
            //TimeLabel.Content = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            TimeLabel.Content = DateTime.Now.TimeOfDay;
        }

        public void Stop()
        {

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainCanvas.Width = e.NewSize.Width;
            MainCanvas.Height = e.NewSize.Height;
        }
    }
}
