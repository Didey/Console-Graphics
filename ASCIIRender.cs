using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ConsoleGraphics
{
    class ASCIIRender
    //convert textures
    {
        public static char[] levels;
        public static Bitmap image1;
        public static byte[,] bitmapColorsCached;

        public static void bt()
        {
            StreamReader r = new StreamReader("levels.txt");
            levels = new char[256];
            int index = 0;
            while (!r.EndOfStream && index < 256)
            {
                string e1 = r.ReadLine();
                levels[index] = Char.Parse(e1);
                index++;
            }
            image1 = (Bitmap)Image.FromFile(@"Lenna.bmp", true);//load character set (digits 1->9..)
            const int WIDTH = 1;
            const int HEIGHT = 1;
            bitmapColorsCached = new byte[image1.Width, image1.Height];

            char[,] shaded = new char[40, 50];

            for (int i = 0; i < image1.Width; i += WIDTH)
            {
                for (int j = 0; j < image1.Height; j += HEIGHT)
                {
                    int sum = 0;
                    for (int i1 = i; i1 < i + WIDTH; i1++)
                    {
                        for (int j1 = j; j1 < j + HEIGHT; j1++)
                        {
                            Color c = image1.GetPixel(i1, j1);
                            sum += c.R + c.B + c.G;
                        }
                    }
                    sum /= WIDTH * HEIGHT * 3;
                   // Console.Write(levels[sum]);
                }
               // Console.WriteLine();
            }
            for (int i = 0; i < image1.Width; i++)
                for (int j = 0; j < image1.Height; j++)
                {
                    Color c = image1.GetPixel(i, j);
                    bitmapColorsCached[i, j] = (byte)((c.R + c.B + c.G) / 3);
                }
        }
    }
}
