using Aura_OS.System.GUI.Imaging;
using Cosmos.HAL;
using System;
using static Cosmos.HAL.Mouse;

namespace Aura_OS.System.GUI
{
    public class Desktop : IScreen
    {

        public Color BackGroundColor = new Color(0xFFFFFF);//hex 

        public void Init()
        {
            //WindowsManager.Desktop.Add(this);
            //init screen and doublebuffer
            Screen.Init();
            //always init mouse agfter screen
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

            //Active_Windows.
            //alwas clear first
            Screen.Clear(BackGroundColor);

            //if (deltaT != RTC.Second)
            //{
            //    FPS = Frames;
            //    Frames = 0;
            //    deltaT = RTC.Second;
            //    Console.Clear();
            //    
            //   
            //}



            //switch (Cursor.Mouse.Buttons)
            //{
            //    case MouseState.Left:
                    //Graphics.DrawString("Left | " + Cursor.Mouse.X + " ; " + Cursor.Mouse.Y, 10, 10, Colors.Black, Internals.Files.Fonts.SegoeUI11_cff);
            //        break;
               // case MouseState.Right:
                    //Graphics.DrawString("Right | " + Cursor.Mouse.X + " ; " + Cursor.Mouse.Y, 10, 10, Colors.Black, Internals.Files.Fonts.SegoeUI11_cff);
                    //WindowsManager.AddWindow(100, 100, 100, 100, "Test Window");
                    //WindowsManager.ShowWindows();
                 //   break;
              //  case MouseState.Middle:
                    //Graphics.DrawString("Middle | " + Cursor.Mouse.X + " ; " + Cursor.Mouse.Y, 10, 10, Colors.Black, Internals.Files.Fonts.SegoeUI11_cff);
               //     break;
              //  case MouseState.None:
                    //Graphics.DrawString("None", 10, 10, Colors.Black, Internals.Files.Fonts.SegoeUI11_cff);
               //     break;
             //   default:
                    //Graphics.DrawString("Unknown event detected!", 10, 10, Colors.Black, Internals.Files.Fonts.SegoeUI11_cff);
                  //  break;
         //   }

            //Graphics.FillRectangle(50, 50, 100, 100, Colors.Black);

            //Graphics.DrawString("FPS: " + FPS, 10, 40, Colors.Black, Internals.Files.Fonts.SegoeUI11_cff);

            //Graphics.DrawImage(Image.Load(Internals.Files.CosmosLogo.Normal), 10, 70);

            //mouse must alwasy be ontop
            Cursor.Render();

            //always redraw last
            Screen.Redraw();

            Frames++;
        }

        public void Handle()
        {
            ReDraw();
        }
    }
}
