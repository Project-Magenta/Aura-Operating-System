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
                            int counter = -1;
                            foreach (Window win in WindowsManager.Active_Windows)
                            {
                                counter++;
                                if (ContainedInClose(win, Mouse.X, Mouse.Y))
                                {
                                    //WindowsManager.Active_Windows.RemoveAt(counter);
                                    Cosmos.System.Power.Shutdown();
                                }
                            }
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