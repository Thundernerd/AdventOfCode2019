using System;
using System.Collections.Generic;
using System.Linq;
using TNRD.AdventOfCode.DayThree.Shared;

namespace TNRD.AdventOfCode.DayThree.PuzzleOne
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 3;

        public PuzzleSolver(string sessionCookie) : base(sessionCookie)
        {
        }

        public override object Solve()
        {
            string[] splits = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            Walker first = new Walker(splits[0]);
            Walker second = new Walker(splits[1]);

            first.Walk();
            second.Walk();

            List<(int, int)> intersections = first.Map.Positions.Intersect(second.Map.Positions)
                .ToList();

            List<int> distances = intersections.Select(x => Math.Abs(x.Item1) + Math.Abs(x.Item2))
                .OrderBy(x => x)
                .ToList();

            return distances[0];
        }
    }
}
