using System;
using System.Collections.Generic;
using TNRD.AdventOfCode.DayTwo.Shared;

namespace TNRD.AdventOfCode.DayTwo.PuzzleOne
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public PuzzleSolver(int day, string sessionCookie) : base(day, sessionCookie)
        {
        }

        public override void Solve()
        {
            List<int> convertedInput = InputConverter.ConvertToIntegers(Input);

            for (int i = 0; i < convertedInput.Count; i += 4)
            {
                if (convertedInput[i] == 99)
                    break;
                IIntCodeProgram program = IntCodeProgramFactory.Create(i, convertedInput);
                program.Execute();
                convertedInput = program.GetOutput();
            }
            
            Console.WriteLine($"Puzzle answer for day {Day} is {convertedInput[0]}");
        }
    }
}
