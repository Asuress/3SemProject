using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Game.Source.Main;
using WPF_Game.Source.Logic;
using WPF_Game.Source.Graphics;
using Point = WPF_Game.Source.Logic.Point;
using Size = WPF_Game.Source.Logic.Size;
using WPF_Game.Source.Physics;
using WPF_Game.Source.FileManagers;

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
        SettingsManager settingsManager = SettingsManager.GetSettingsManager();
        public void Start()
        {
            settingsManager.ReadSettings();
            ImageBrush playerIMG = new ImageBrush(new BitmapImage(new Uri(settingsManager.Settings["PlayerImgPath"], UriKind.Absolute)));
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
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _Scene.Width = e.NewSize.Width;
            _Scene.Height = e.NewSize.Height;
        }
    }
}
