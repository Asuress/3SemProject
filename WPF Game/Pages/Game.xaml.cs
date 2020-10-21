using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Game.Source.Main;
using WPF_Game.Source.Logic;
using WPF_Game.Source.Graphics;
using Transform = WPF_Game.Source.Components.Transform;
using Point = WPF_Game.Source.Logic.Point;
using Size = WPF_Game.Source.Logic.Size;
using WPF_Game.Source.Physics;

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
            _Scene = Scene.GetInstance();
            MainViewbox.Child = _Scene;
        }
        Scene _Scene;
        EnemyControl EnemyController;
        GameObject Player;
        public void Start()
        {
            ImageBrush playerIMG = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Admin\source\repos\3SemProject\WPF Game\source\images\Player.png", UriKind.Absolute)));
            Shape playerEllipse = new Ellipse();
            Point pt = new Point(Application.Current.MainWindow.ActualWidth / 2, Application.Current.MainWindow.ActualHeight / 2);
            Size sz = new Size(20, 20);

            Player = new GameObject(playerEllipse, playerIMG, pt, sz);
            Player.Collider = new BoxCollider(Player, _Scene);

            _Scene.Background = Brushes.DarkOliveGreen;
            _Scene.AddGameObject(Player);
            EnemyController = new EnemyControl(Player, _Scene);
            EnemyController.StartSpawn();
        }
        public void Stop()
        {

        }
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _Scene.Width = e.NewSize.Width;
            _Scene.Height = e.NewSize.Height;
        }
    }
}
