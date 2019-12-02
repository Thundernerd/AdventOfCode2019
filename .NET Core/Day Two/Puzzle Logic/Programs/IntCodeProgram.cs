using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public abstract class IntCodeProgram : IIntCodeProgram
    {
        private readonly List<int> program;
        private readonly List<int> rom;
        private readonly List<int> ram;

        protected IntCodeProgram(List<int> program, List<int> rom)
        {
            this.program = program;
            this.rom = rom;
            ram = new List<int>(rom);
        }

        public abstract void Execute();

        public int GetNoun()
        {
            return rom[program[1]];
        }

        public int GetVerb()
        {
            return rom[program[2]];
        }

        protected void WriteOutput(int value)
        {
            ram[program[3]] = value;
        }

        public List<int> GetRam()
        {
            return ram;
        }
    }
}
