namespace TNRD.AdventOfCode.Foundation
{
    public interface IPuzzleSolver
    {
        int Day { get; }
        object Solve();
    }
}
