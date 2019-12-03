namespace TNRD.AdventOfCode.Foundation
{
    public abstract class PuzzleSolver : IPuzzleSolver
    {
        public abstract int Day { get; }

        public abstract object Solve(string input);
    }
}
