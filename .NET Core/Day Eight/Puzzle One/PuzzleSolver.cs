using System.Collections.Generic;
using System.Linq;
using TNRD.AdventOfCode.DayEight.Shared;

namespace TNRD.AdventOfCode.DayEight.PuzzleOne
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 8;

        public override object Solve(string input)
        {
            List<int> pixels = ConvertInput(input.Trim());

            Image image = new Image(25, 6);
            image.SetPixels(pixels);

            List<List<int>> layerValues = image.Layers
                .Select(x => x.GetValues())
                .OrderBy(x => x.Count(y => y == 0))
                .ToList();

            List<int> layer = layerValues.First();
            int amount = layer.Count(x => x == 1) * layer.Count(x => x == 2);

            return amount;
        }

        private List<int> ConvertInput(string input)
        {
            return input.Select(x => x)
                .Select(x => int.Parse(x.ToString()))
                .ToList();
        }
    }
}
