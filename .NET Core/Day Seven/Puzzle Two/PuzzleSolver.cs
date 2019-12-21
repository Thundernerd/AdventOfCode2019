using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNRD.AdventOfCode.DaySeven.Shared;

namespace TNRD.AdventOfCode.DaySeven.PuzzleTwo
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 7;

        private string input;
        private List<(string, int)> outputs;

        public override object Solve(string input)
        {
            this.input = input;
            this.outputs = new List<(string, int)>();

            DistinctNumber distinctNumber = new DistinctNumber(5, 9, 5);
            List<int> list = distinctNumber.ToList();

            Parallel.ForEach(list, ExecuteChain);

            return outputs.OrderByDescending(x => x.Item2)
                .First();
        }

        private void ExecuteChain(int i)
        {
            string phaseSettings = i.ToString("D5");
            AmplifierChain chain = new AmplifierChain(phaseSettings, input);
            Console.WriteLine($"Starting Chain {phaseSettings}");
            chain.Run();
            Console.WriteLine($"Setting: {chain.PhaseSettings}; Output: {chain.Output}");
            outputs.Add((chain.PhaseSettings, chain.Output));
        }
    }
}
