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
                    switch (Mouse.Buttons)
                    {
                        case Mouse.MouseState.Left:

                            break;
                        case Mouse.MouseState.Right:

                            break;
                        case Mouse.MouseState.Middle:

                            break;
                        case Mouse.MouseState.None:

                            break;
                        default:

                            break;
                    }
                    Graphics.DrawImage(Image, Mouse.X, Mouse.Y, Colors.White);
                }
            }
        }
    }
}