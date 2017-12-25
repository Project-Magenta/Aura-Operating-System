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
            Mouse.Initialize((uint)Screen.Vbe.ScreenWidth, (uint)Screen.Vbe.ScreenHeight);
        }

        public static void Render()
        {
            if (Image != null)
            {
                if (Enabled)
                {
                    Graphics.DrawImage(Image, Mouse.X, Mouse.Y, Colors.White);
                }
            }
        }

        public static bool ContainedInClose(Window window, int X, int Y)
        {
            if (X >= window.CloseArea.X && X <= window.CloseArea.XMAX && Y >= window.CloseArea.Y && Y <= window.CloseArea.YMAX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}