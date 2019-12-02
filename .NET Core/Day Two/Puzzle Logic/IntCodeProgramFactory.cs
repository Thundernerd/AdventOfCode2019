using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public static class IntCodeProgramFactory
    {
        private enum OpCode
        {
            Addition = 1,
            Multiplication = 2
        }

        public static IIntCodeProgram Create(int index, List<int> input)
        {
            List<int> program = input.GetRange(index, 4);

            switch ((OpCode) program[0])
            {
                case OpCode.Addition:
                    return new AddIntCodeProgram(program, input);
                case OpCode.Multiplication:
                    return new MultiplyIntCodeProgram(program, input);
            }

            return null;
        }
    }
}
