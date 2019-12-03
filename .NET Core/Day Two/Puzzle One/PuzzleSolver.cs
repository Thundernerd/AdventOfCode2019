using System.Collections.Generic;
using TNRD.AdventOfCode.DayTwo.Shared;

namespace TNRD.AdventOfCode.DayTwo.PuzzleOne
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 2;

        public PuzzleSolver()
        {
        }

        public override object Solve(string input)
        {
            List<int> memory = InputConverter.CreateMemory(input);

            for (int pointer = 0; pointer < memory.Count; pointer += 4)
            {
                if (IntCodeProgramFactory.GetInstruction(pointer, memory) == IntCodeProgramFactory.Instruction.Halt)
                    break;

                IIntCodeProgram program = IntCodeProgramFactory.Create(pointer, memory);
                program.Execute();
                memory = program.GetRam();
            }

            return memory[0];
        }
    }
}
