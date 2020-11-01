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
using System.Windows.Input;
using WPF_Game.Source.Components;

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
            scene = Scene.GetInstance();
            MainViewbox.Child = scene;
            scene.Loaded += Scene_Loaded;
        }

        Scene scene;
        EnemyControl enemyController;
        GameObject player;
        SettingsManager settingsManager = SettingsManager.GetSettingsManager();

        public void Start()
        {
            settingsManager.ReadSettings();
            ImageBrush playerIMG = new ImageBrush(new BitmapImage(new Uri(settingsManager.Settings["PlayerImgPath"], UriKind.Absolute)));
            Shape playerEllipse = new Ellipse();
            Point pt = new Point(Application.Current.MainWindow.ActualWidth / 2, Application.Current.MainWindow.ActualHeight / 2);
            Size sz = new Size(20, 20);

            player = new GameObject(playerEllipse, playerIMG, pt, sz);

            player.AddComponent(new BoxCollider(player, scene));
            player.AddComponent(new Rigidbody(player));
            player.AddComponent(new Controller(player, double.Parse(settingsManager.Settings["PlayerSpeed"])));

            scene.Background = Brushes.DarkOliveGreen;
            scene.AddGameObject(player);
            enemyController = new EnemyControl(player, scene);
            enemyController.StartSpawn();

        }

        public void Stop()
        {

        }

        private void Scene_Loaded(object sender, RoutedEventArgs e)
        {
            scene.Focusable = true;
            Keyboard.Focus(scene);
        }
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scene.Width = e.NewSize.Width;
            scene.Height = e.NewSize.Height;
        }
    }
}
