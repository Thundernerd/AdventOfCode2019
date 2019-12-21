using System;
using System.Collections.Generic;
using System.Linq;
using TNRD.AdventOfCode.DaySeven.Shared;

namespace TNRD.AdventOfCode.DaySeven.PuzzleOne
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 7;

        public override object Solve(string input)
        {
            List<(string, int)> outputs = new List<(string,int)>();

            DistinctNumber distinctNumber = new DistinctNumber(0, 4, 5);
            foreach (var i in distinctNumber)
            {
                string phaseSettings = i.ToString("D5");
                AmplifierChain chain = new AmplifierChain(phaseSettings, input);
                chain.Run();
                Console.WriteLine($"Setting: {chain.PhaseSettings}; Output: {chain.Output}");
                outputs.Add((chain.PhaseSettings,chain.Output));
            }

            return outputs.OrderByDescending(x => x.Item2)
                .First();
        }
    }
}
