using Aura_OS.System.GUI.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura_OS.System.GUI
{
    public abstract class Graphics
    {
        public string Name;

        public Graphics()
        {
            Shell.cmdIntr.CommandManager.driver = this;   
        }

        public abstract void DrawLine(int x, int y, int x2, int y2, Color color);

        public abstract void DrawRectangle(int x, int y, int w, int h, Color color);

        public abstract void FillRectangle(int x, int y, int w, int h, Color color);

        public abstract int DrawChar(char c, int x, int y, Color color, Font f);

        public abstract void DrawString(string c, int x, int y, Color color, Font f);

        public abstract void DrawImage(Image img, int x, int y, Color TransparencyKey = null);

    }
}
