using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public interface IIntCodeProgram
    {
        void Execute();
        List<int> GetOutput();
    }
}
