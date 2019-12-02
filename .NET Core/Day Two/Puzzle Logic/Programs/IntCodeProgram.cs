using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public abstract class IntCodeProgram : IIntCodeProgram
    {
        private readonly List<int> program;
        private readonly List<int> input;
        private readonly List<int> output;

        protected IntCodeProgram(List<int> program, List<int> input)
        {
            this.program = program;
            this.input = input;
            output = new List<int>(input);
        }

        public abstract void Execute();

        protected int GetFirstInput()
        {
            return input[program[1]];
        }

        protected int GetSecondInput()
        {
            return input[program[2]];
        }

        protected void WriteOutput(int value)
        {
            output[program[3]] = value;
        }

        public List<int> GetOutput()
        {
            return output;
        }
    }
}
