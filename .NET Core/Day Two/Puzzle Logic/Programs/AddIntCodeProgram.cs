using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public class AddIntCodeProgram : IntCodeProgram
    {
        internal AddIntCodeProgram(List<int> program, List<int> input) : base(program, input)
        {
        }

        public override void Execute()
        {
            WriteOutput(GetFirstInput() + GetSecondInput());
        }
    }
}
