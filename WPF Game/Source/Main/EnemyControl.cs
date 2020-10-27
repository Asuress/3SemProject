using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Game.Source.Graphics;
using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Main
{
    public class EnemyControl : GameManager
    {
        public EnemyControl(GameObject target, Scene scene)
        {
            Scene = scene;
            Target = target;
        }

        Scene Scene;
        Random Rand = new Random();
        public int MaxCountOfEnemy
        {
            get
            {
                return _MaxCountOfEnemy;
            }
            set
            {
                _MaxCountOfEnemy = value > 0 ? value : 0;
            }
        }

        private bool CanSpawn = false;
        private int _MaxCountOfEnemy = 10;
        private LinkedList<Enemy> Enemies = new LinkedList<Enemy>();
        private GameObject Target;
        protected override void Update()
        {
            if (Enemies.Count < MaxCountOfEnemy && CanSpawn)
            {
                SpawnEnemy();
            }
            foreach (var enemy in Enemies)
            {
                Ellipse ellipse = (Ellipse)enemy.Shape;
                
            }
        }
        
        public void StartSpawn()
        {
            CanSpawn = true;
        }
        public void StopSpawn()
        {
            CanSpawn = false;
        }
        private void SpawnEnemy()
        {
            Enemy enemy = new Enemy(Target);
            enemy.Transform.Position = new Logic.Point(Rand.Next(0, 300), Rand.Next(0, 300));
            enemy.Transform.Size = new Logic.Size(15, 15);
            Enemies.AddLast(enemy);
            Scene.AddGameObject(enemy);
            //Scene.UpdateLayout();
        }
    }
}
