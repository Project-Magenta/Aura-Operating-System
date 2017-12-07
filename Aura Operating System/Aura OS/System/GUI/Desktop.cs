using Aura_OS.System.GUI.Imaging;
using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura_OS.System.GUI
{
    public class Desktop : IScreen
    {
        public Color BackGroundColor = new Color(0xffffff);//hex 

        public void Init()
        {
            Screen.Init();
            Cursor.Init();
            Cursor.Enabled = true;
            Screen.Clear(BackGroundColor, true);
            deltaT = RTC.Second;
            Cursor.Image = Image.Load(Internals.Files.Cursors.Normal);
        }

        int c = 0;
        int Frames = 0;
        int FPS = 0;
        int deltaT = 0;
        public void ReDraw()
        {
            //alwas clear first
            Screen.Clear(BackGroundColor);

            if (deltaT != RTC.Second)
            {
                FPS = Frames;
                Frames = 0;
                deltaT = RTC.Second;
                Console.Clear(); 
            }

            //Shell.cmdIntr.CommandManager.driver.DrawString("FPS: " + FPS, 10, 10, Colors.Black, Internals.Files.Fonts.Consolas14_cff);

            //Shell.cmdIntr.CommandManager.driver.DrawString("Hello from Aura Operating System!", 10, 50, Colors.Red, Internals.Files.Fonts.SegoeUI11_cff);

            Image wallpaper = Image.Load(Files.Images.Wallpaper);

            Shell.cmdIntr.CommandManager.driver.DrawImage(wallpaper, 0, 0);

            //Graphics.DrawLine(50, 50, 100, 70 + 50, Colors.Black);

            //Graphics.DrawRectangle(50, 50, 50, 50, Colors.Black);

            //mouse must alwasy be ontop


            Cursor.Render();
            Screen.Redraw();
            Frames++;
        }

        public void Handle()
        {
            ReDraw();
        }
    }
}
