using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPF_Game.Source.Graphics;

namespace WPF_Game.Source.Main
{
    public class Input
    {
        public Input(Scene _scene)
        {
            
        }
        public static bool IsKeyDown(Key key)
        {
            return Keyboard.IsKeyDown(key);
        }
        public static bool IsKeyToggled(Key key)
        {
            return Keyboard.IsKeyToggled(key);
        }
        public static bool IsKeyUp(Key key)
        {
            return Keyboard.IsKeyUp(key);
        }
    }
}
