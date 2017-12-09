using System;
using System.Collections.Generic;
using System.Text;

namespace Aura_OS.System.GUI
{
    public class WindowsManager
    {

        public static List<Window> Active_Windows { get; protected set; } = new List<Window>();

        public static void AddWindow(int sizex, int sizey, int posx, int posy, string name)
        {
            Window win = new Window();
            Point position = new Point(posx, posy);
            Point size = new Point(sizex, sizey);
            win.pos = position;
            win.size = size;
            win.Name = name;
            AddWindow(win);
        }

        public static void AddWindow(Window window)
        {
            Active_Windows.Add(window);
        }

        public static void ShowWindows()
        {
            foreach (Window wind in Active_Windows)
            {
                wind.Draw();
            }
        }
    }

    public class Window
    {

        public string Name;

        public Point pos;

        public Point size;

        public Area CloseArea;

        public void Draw()
        {
            Graphics.FillRectangle(pos.X, pos.Y - 20 , size.X, 20, Colors.AliceBlue);
            Graphics.DrawString(Name, pos.X, pos.Y - 22, Colors.Black, Internals.Files.Fonts.SegoeUI11_cff);
            Graphics.FillRectangle(pos.X, pos.Y, size.X, size.Y, Colors.LightGray);
            Graphics.DrawRectangle(pos.X - 1, pos.Y - 21, size.X + 2, size.Y + 22, Colors.DarkGray);
            Graphics.FillRectangle(pos.X + size.X -19, pos.Y - 20, 19, 19, Colors.Red);
            CloseArea.X = pos.X + size.X - 19;
            CloseArea.Y = pos.Y - 20;
            CloseArea.XMAX = CloseArea.X + 19;
            CloseArea.YMAX = CloseArea.Y +  19;
        }

    }

    public enum WindowState
    {

        fullscreen = 0x01,
        min = 0x02,
        max = 0x03,
        windowed = 0x04,

    }

    public enum BorderStyle
    {

        None = 0x00,
        Fixed3D = 0x10,
        FixedDialog = 0x11,
        FixedSingle = 0x12,
        FixedToolWindow = 0x13,
        Sizable = 0x20,
        SizableToolWindow = 0x21

    }
}
