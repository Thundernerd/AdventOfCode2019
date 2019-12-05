using TNRD.AdventOfCode.DayFive.Shared;

namespace TNRD.AdventOfCode.DayFive.PuzzleTwo
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 5;

        public override object Solve(string input)
        {
            var emulator = new Emulator();
            emulator.Run(input);
            return "see previous output";
        }
    }
}
