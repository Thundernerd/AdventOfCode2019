using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public class MultiplyIntCodeProgram : IntCodeProgram
    {
        internal MultiplyIntCodeProgram(List<int> program, List<int> input) : base(program, input)
        {
        }

        public override void Execute()
        {
            WriteOutput(GetFirstInput() * GetSecondInput());
        }
    }
}
