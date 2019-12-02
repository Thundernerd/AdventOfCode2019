using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public static class IntCodeProgramFactory
    {
        public enum Instruction
        {
            Addition = 1,
            Multiplication = 2,
            Halt = 99
        }

        public static IIntCodeProgram Create(int pointer, List<int> memory)
        {
            List<int> program = memory.GetRange(pointer, 4);

            switch (GetInstruction(pointer, memory))
            {
                case Instruction.Addition:
                    return new AddIntCodeProgram(program, memory);
                case Instruction.Multiplication:
                    return new MultiplyIntCodeProgram(program, memory);
            }

            return null;
        }

        public static Instruction GetInstruction(int pointer, List<int> memory)
        {
            return (Instruction) memory[pointer];
        }
    }
}
