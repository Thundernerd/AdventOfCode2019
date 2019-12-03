using System;
using System.Collections.Generic;
using System.Linq;
using TNRD.AdventOfCode.DayThree.Shared;

namespace TNRD.AdventOfCode.DayThree.PuzzleTwo
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 3;

        public PuzzleSolver()
        {
        }

        public override object Solve(string input)
        {
            string[] splits = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            Walker first = new Walker(splits[0]);
            Walker second = new Walker(splits[1]);

            first.Walk();
            second.Walk();

            List<(int, int)> intersections = first.Map.Positions.Intersect(second.Map.Positions)
                .ToList();

            List<int> orderedLengths = intersections
                .Select(x => first.Map.PositionToLength[x] + second.Map.PositionToLength[x])
                .OrderBy(x => x)
                .ToList();

            return orderedLengths[0];
        }
    }
}
