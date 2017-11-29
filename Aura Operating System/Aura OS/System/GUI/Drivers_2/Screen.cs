

namespace Aura_OS.System.GUI
{
    public abstract class Screen
    {

        public string Name;

        public int ScreenWidth;

        public int ScreenHeight;

        public Screen()
        {
            Shell.cmdIntr.CommandManager.Screens = this;
        }

        public abstract void Init();

        public abstract void Clear(int color, bool Frame = false);

        public abstract void SetPixel(int x, int y, int c);

        public abstract void Redraw();

    }
}