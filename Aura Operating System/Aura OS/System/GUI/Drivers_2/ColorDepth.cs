using System;
using System.Collections.Generic;
using System.Text;

namespace Aura_OS.System.GUI
{
    public enum ColorDepth
    {
        ColorDepth4 = 4,   /* EGA 16 colors */
        ColorDepth8 = 8,   /* VGA 256 colors */
        ColorDepth16 = 16, /* 65535 colors */
        ColorDepth24 = 24, /* 16,777,216 of colors */
        ColorDepth32 = 32  /* 16,777,216 of colors (with transparency). Use this when in doubt :-) */
    }
}
