using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayEight.Shared
{
    public class Image
    {
        public int Width { get; }
        public int Height { get; }
        public int Length { get; }

        public List<Layer> Layers { get; private set; }

        public Image(int width, int height)
        {
            Width = width;
            Height = height;
            Length = width * height;
        }

        public void SetPixels(List<int> pixels)
        {
            Layers = new List<Layer>();

            for (int i = 0; i < pixels.Count; i += Length)
            {
                List<int> range = pixels.GetRange(i, Length);
                Layer layer = new Layer(Width, Height);
                layer.SetPixels(range);
                Layers.Add(layer);
            }
        }
    }
}
