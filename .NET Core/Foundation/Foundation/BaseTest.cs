using NUnit.Framework;

namespace TNRD.AdventOfCode.Foundation
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected void ExecuteTest(string input, object expectedAnswer)
        {
            IPuzzleSolver puzzleSolver = PuzzleSolverFactory.Create();
            object answer = puzzleSolver.Solve(input);
            Assert.AreEqual(answer, expectedAnswer);
        }
    }
}
