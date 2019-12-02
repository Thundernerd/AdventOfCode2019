using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public class MultiplyIntCodeProgram : IntCodeProgram
    {
        internal MultiplyIntCodeProgram(List<int> program, List<int> rom) : base(program, rom)
        {
        }

        public override void Execute()
        {
            WriteOutput(GetNoun() * GetVerb());
        }
    }
}
