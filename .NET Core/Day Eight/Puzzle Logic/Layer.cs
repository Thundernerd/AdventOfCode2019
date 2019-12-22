using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayEight.Shared
{
    public class Layer
    {
        public int Width { get; }
        public int Height { get; }

        private int[,] pixels;

        public Layer(int width, int height)
        {
            Width = width;
            Height = height;

            pixels = new int[width, height];
        }

        public void SetPixels(List<int> pixels)
        {
            for (int i = 0; i < pixels.Count; i++)
            {
                int w = i % Width;
                int h = i / Width;
                this.pixels[w, h] = pixels[i];
            }
        }

        public int GetValue(int x, int y)
        {
            return pixels[x, y];
        }

        public List<int> GetValues()
        {
            List<int> values = new List<int>();
            
            foreach (var pixel in pixels)
            {
                values.Add(pixel);
            }

            return values;
        }
    }
}
