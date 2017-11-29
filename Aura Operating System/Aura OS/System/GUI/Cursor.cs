using Aura_OS.System.GUI.Imaging;
using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura_OS.System.GUI
{
    public static class Cursor
    {
        public static bool Enabled { get; set; }
        public static Image Image;

        public static Mouse Mouse = new Mouse();

        public static void Init()
        {
            Mouse.Initialize((uint)Shell.cmdIntr.CommandManager.Screens.ScreenWidth, (uint)Shell.cmdIntr.CommandManager.Screens.ScreenHeight);
        }

        public static void Render()
        {
            if(Image != null)
            {
                if(Enabled)
                {
                    Graphics.DrawImage(Image, Mouse.X, Mouse.Y, Colors.White);
                }
            }
        }
    }
}