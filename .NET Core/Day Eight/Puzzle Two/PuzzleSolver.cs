using System;
using System.Collections.Generic;
using System.Linq;
using TNRD.AdventOfCode.DayEight.Shared;

namespace TNRD.AdventOfCode.DayEight.PuzzleTwo
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 8;

        public override object Solve(string input)
        {
            List<int> pixels = ConvertInput(input.Trim());

            Image image = new Image(25, 6);
            image.SetPixels(pixels);

            int[,] combined = CombineLayers(image);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color value = (Color) combined[x, y];
                    switch (value)
                    {
                        case Color.Black:
                            Console.Write(" ");
                            break;
                        case Color.White:
                            Console.Write("█");
                            break;
                    }
                }
                Console.WriteLine();
            }
            
            return "See above";
        }

        private List<int> ConvertInput(string input)
        {
            return input.Select(x => x)
                .Select(x => int.Parse(x.ToString()))
                .ToList();
        }

        private int[,] CombineLayers(Image image)
        {
            int[,] combined = new int[image.Width, image.Height];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    combined[x, y] = GetValue(image, x, y);
                }
            }

            return combined;
        }

        private int GetValue(Image image, int x, int y)
        {
            foreach (Layer layer in image.Layers)
            {
                int value = layer.GetValue(x, y);
                if (value != (int) Color.Transparent)
                    return value;
            }

            throw new Exception("Oops");
        }
    }
}
