using System;
using System.Collections.Generic;
using System.Text;

namespace Aura_OS.System.GUI
{
    public unsafe class ScreenSVGAII : Screen
    {
        public override void Clear(int color, bool Frame = false)
        {
            throw new NotImplementedException();
        }

        public override void Init()
        {
            Name = "SVGAII Screen";
            Console.WriteLine(Name);
        }

        public override void Redraw()
        {
            throw new NotImplementedException();
        }

        public override void SetPixel(int x, int y, int c)
        {
            throw new NotImplementedException();
        }
    }
}
