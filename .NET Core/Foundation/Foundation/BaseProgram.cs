using System;

namespace TNRD.AdventOfCode.Foundation
{
    public class BaseProgram
    {
        protected static void CreateAndSolve()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.Create();
            object answer = solver.Solve();
            Console.WriteLine($"Answer for day {solver.Day} is {answer}");
        }
    }
}
