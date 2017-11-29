using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL.Drivers.PCI.Video;

namespace Aura_OS.System.GUI
{
    public unsafe class ScreenSVGAII : Screen
    {

        public SVGAIIScreen svgaii = new SVGAIIScreen();

        public VMWareSVGAII xSVGAIIDriver;

        public byte[] BackBuffer = new byte[0];

        public List<int> X_Changes = new List<int>();
        public List<int> Y_Changes = new List<int>();
        public List<int> C_Changes = new List<int>();

        public int ScreenBpp { get; set; }

        public override void Init()
        {
            Name = "SVGAII Screen";

            //Vbe.SetMode(VBEScreen.ScreenSize.Size800x600, VBEScreen.Bpp.Bpp24);
            svgaii.SetMode(SVGAIIScreen.ScreenSize.Size1024x768, SVGAIIScreen.Bpp.Bpp24);

            BackBuffer = new byte[(svgaii.ScreenHeight * svgaii.ScreenWidth) * 3];

            ScreenHeight = svgaii.ScreenHeight;
            ScreenWidth = svgaii.ScreenWidth;

            for (int i = 0; i < BackBuffer.Length; i++)
            {
                BackBuffer[0] = 0;
            }
        }

        public override void Clear(int color, bool Frame = false)
        {
            xSVGAIIDriver.Fill(0, 0, (uint)svgaii.ScreenWidth, (uint)svgaii.ScreenHeight, (uint)color);
        }

        public override void Redraw()
        {
            for (int i = 0; i < X_Changes.Count; i++)
            {
                var x = X_Changes[i];
                var y = Y_Changes[i];
                var c = C_Changes[i];

                var where = x * ((uint)ScreenBpp / 8) + y * (uint)(svgaii.ScreenWidth * ((uint)ScreenBpp / 8));
                BackBuffer[where] = (byte)(c & 255);              // BLUE
                BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED


            }

            svgaii.SetBuffer(BackBuffer);
        }

        public override void SetPixel(int x, int y, int c)
        {
            X_Changes.Add(x);
            Y_Changes.Add(y);
            C_Changes.Add(c);
            //mSVGAIIDebugger.SendInternal($"Drawing point to x:{x}, y:{y} with {xColor.Name} Color");
            xSVGAIIDriver.SetPixel((uint)x, (uint)y, (uint)c);
            //mSVGAIIDebugger.SendInternal($"Done drawing point");
            xSVGAIIDriver.Update(0, 0, (uint)svgaii.ScreenWidth, (uint)svgaii.ScreenHeight);
        }
    }
}
