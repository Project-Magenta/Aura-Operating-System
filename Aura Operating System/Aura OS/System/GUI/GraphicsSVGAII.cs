﻿using Aura_OS.System.GUI.Imaging;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura_OS.System.GUI
{
    class GraphicsSVGAII : Graphics
    {

        public VMWareSVGAII xSVGAIIDriver;

        public static Pen pen;


        public override void DrawLine(int x, int y, int x2, int y2, Color color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = w;
            int shortest = h;
            if (!(longest > shortest))
            {
                longest = h;
                shortest = w;
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                int colour = color;
                xSVGAIIDriver.SetPixel((uint)x, (uint)y, (uint)colour);
                xSVGAIIDriver.Update(0, 0, (uint)Screen.canvas.Mode.Columns, (uint)Screen.canvas.Mode.Rows);

                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        public override void DrawRectangle(int x, int y, int w, int h, Color color)
        {
            DrawLine(x, y, x, y + h, color);
            DrawLine(x, y, x + w, y, color);
            DrawLine(x, y + h, x + w, y + h, color);
            DrawLine(x + w, y, x + w, y + h, color);
        }


        public override void FillRectangle(int x, int y, int w, int h, Color color)
        {
            DrawLine(x, y, x, y + h, color);
            DrawLine(x, y, x + w, y, color);
            DrawLine(x, y + h, x + w, y + h, color);
            DrawLine(x + w, y, x + w, y + h, color);

            for (int i = 0; i < h; i++)
            {
                DrawLine(x, y + i, x + w, y + i, color);
            }
        }

        public override int DrawChar(char c, int x, int y, Color color, Font f)
        {
            var index = 0;
            for (int i = 0; i < f.Char.Count; i++)
            {
                if (c == f.Char[i])
                {
                    index = i;
                    break;
                }
            }

            var width = f.Width[index];

            int z = 0;
            for (int p = y; p < y + f.Height[index]; p++)
            {
                for (int i = x; i < x + width; i++)
                {
                    if (f.Data[index][z] == 1)
                    {

                        
                        pen = new Pen(ColorstoColors.Convert(color));
                        Screen.canvas.DrawPoint(pen, i, p);

                    }

                    z++;
                }
            }

            return width;
        }

        public override void DrawString(string c, int x, int y, Color color, Font f)
        {
            int totalwidth = 0;
            for (int i = 0; i < c.Length; i++)
            {
                

                var ch = c[i];
                if (ch == ' ')
                {
                    totalwidth += f.Width[0];
                }
                else if (ch == '\t')
                {
                    totalwidth += (f.Width[0] * 4);
                }
                else
                {
                    totalwidth += DrawChar(ch, x + totalwidth, y, color, f);
                }

            }
        }

        public override void DrawImage(Image img, int x, int y, Color TransparencyKey = null)
        {
            int z = 0;
            for (int p = y; p < y + img.Height; p++)
            {
                for (int i = x; i < x + img.Width; i++)
                {
                    if (TransparencyKey != null)
                    {
                        if (img.Map[z] != TransparencyKey.ToHex())
                        {
                            int colour = img.Map[z];
                            xSVGAIIDriver.SetPixel((uint)i, (uint)p, (uint)colour);
                            xSVGAIIDriver.Update(0, 0, (uint)Screen.canvas.Mode.Columns, (uint)Screen.canvas.Mode.Rows);
                        }
                    }
                    else
                    {
                        int colour = img.Map[z];
                        xSVGAIIDriver.SetPixel((uint)i, (uint)p, (uint)colour);
                        xSVGAIIDriver.Update(0, 0, (uint)Screen.canvas.Mode.Columns, (uint)Screen.canvas.Mode.Rows);
                    }

                    z++;
                }
            }
        }
    }

    public static class ColorstoColors
    {

        public static Cosmos.System.Graphics.Color Convert(Color color)
        {
            if (color == Colors.Black)
            {
                return Cosmos.System.Graphics.Color.Black;
            }
            else if (color == Colors.White)
            {
                return Cosmos.System.Graphics.Color.White;
            }
            else if (color == Colors.Red)
            {
                return Cosmos.System.Graphics.Color.Red;
            }
            else
            {
                return null;
            }
        }
    }
}
