using System;
using System.Collections.Generic;
using TNRD.AdventOfCode.DayTwo.Shared;

namespace TNRD.AdventOfCode.DayTwo.PuzzleTwo
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public PuzzleSolver(int day, string sessionCookie) : base(day, sessionCookie)
        {
        }

        public override void Solve()
        {
            List<int> memory = InputConverter.ConvertToIntegers(Input);
            int result = 0;

            for (int pointer = 0; pointer < memory.Count; pointer += 4)
            {
                if (IntCodeProgramFactory.GetInstruction(pointer, memory) == IntCodeProgramFactory.Instruction.Halt)
                    break;

                IIntCodeProgram program = IntCodeProgramFactory.Create(pointer, memory);
                program.Execute();
                List<int> ram = program.GetRam();

                if (ram[pointer] == 19690720)
                {
                    result = 100 * program.GetNoun() + program.GetVerb();
                    break;
                }
            }

            Console.WriteLine($"Puzzle answer for day {Day} is {result}");
        }
    }
}
