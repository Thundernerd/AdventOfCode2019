using System.Collections.Generic;
using TNRD.AdventOfCode.DayTwo.Shared;

namespace TNRD.AdventOfCode.DayTwo.PuzzleTwo
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 2;

        public PuzzleSolver(string sessionCookie) : base(sessionCookie)
        {
        }

        public override object Solve()
        {
            int noun = 0;
            int verb = 0;
            int? result = null;

            while (noun < 100 && verb < 100)
            {
                List<int> memory = InputConverter.CreateMemory(Input, noun, verb);

                for (int pointer = 0; pointer < memory.Count; pointer += 4)
                {
                    if (IntCodeProgramFactory.GetInstruction(pointer, memory) == IntCodeProgramFactory.Instruction.Halt)
                        break;

                    IIntCodeProgram program = IntCodeProgramFactory.Create(pointer, memory);
                    program.Execute();
                    memory = program.GetRam();
                }

                if (memory[0] == 19690720)
                {
                    result = 100 * noun + verb;
                    break;
                }

                if (noun < 99)
                    ++noun;
                else
                {
                    noun = 0;
                    ++verb;
                }
            }

            return result;
        }
    }
}
