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
            if (Shell.cmdIntr.CommandManager.Graphic == "svgaii")
            {
                Mouse.Initialize((uint)Screen.Vbe.ScreenWidth, (uint)Screen.Vbe.ScreenHeight);
            }
            else
            {
                Mouse.Initialize((uint)1024, (uint)768);
            }
                
        }

        public static void Render()
        {
            if(Image != null)
            {
                if(Enabled)
                {
                    Shell.cmdIntr.CommandManager.driver.DrawImage(Image, Mouse.X, Mouse.Y, Colors.White);
                }
            }
        }
    }
}