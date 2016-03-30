using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace whitenessToAlpha
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap(args[0]);

            int lastPercent = -1;

            int numPixels = bmp.Width * bmp.Height;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);

                    int whiteness = Math.Min(c.R, c.G);
                    whiteness = Math.Min(whiteness, c.B);

                    int a = c.A - whiteness;
                    int r = c.R - whiteness;
                    int g = c.G - whiteness;
                    int b = c.B - whiteness;

                    if (a < 0)
                        a = 0;

                    if (r < 0)
                        r = 0;

                    if (g < 0)
                        g = 0;

                    if (b < 0)
                        b = 0;

                    c = Color.FromArgb(a, r, g, b);

                    bmp.SetPixel(x, y, c);
                    
                    int percent = (int)((x + (y * bmp.Width)) / (double)numPixels * 100 + 0.5);
                    if (percent > lastPercent)
                    {
                        lastPercent = percent;
                        Console.WriteLine("Complete: " + percent + "%");
                    }
                }
            }
            bmp.Save("new.png");
        }
    }
}
