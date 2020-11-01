using System;
using System.Timers;

namespace WPF_Game.Source.Main
{
    class Time
    {
        public Time()
        {
            
        }

        public static double DeltaTime
        {
            get { return 1d / GameManager.FPS; }
        }
    }
}
