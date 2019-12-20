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
            
            for (int i = 0; i < 44445; i++)
            {
                string phaseSettings = i.ToString("D5");
                bool areAllSingle = phaseSettings.GroupBy(x => x)
                    .Select(x => x.Count())
                    .All(x => x == 1);

                if (!areAllSingle)
                {
                    continue;
                }

                if (!phaseSettings.All(x => int.Parse(x.ToString()) < 5))
                {
                    continue;
                }

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
