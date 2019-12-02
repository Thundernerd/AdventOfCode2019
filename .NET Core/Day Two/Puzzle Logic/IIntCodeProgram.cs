using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public interface IIntCodeProgram
    {
        void Execute();
        int GetNoun();
        int GetVerb();
        List<int> GetRam();
    }
}
