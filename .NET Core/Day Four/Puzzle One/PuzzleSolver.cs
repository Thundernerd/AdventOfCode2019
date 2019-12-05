using System;
using TNRD.AdventOfCode.DayFour.Shared;

namespace TNRD.AdventOfCode.DayFour.PuzzleOne
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 4;

        public override object Solve(string input)
        {
            string[] splits = input.Trim().Split('-', StringSplitOptions.RemoveEmptyEntries);
            int min = int.Parse(splits[0]);
            int max = int.Parse(splits[1]);
            PasswordValidator validator = new PasswordValidator(
                new IncreasingDigitRule(),
                new DuplicateAdjacentDigitsRule(1));

            int countValid = 0;

            for (int i = min; i < max; i++)
            {
                if (validator.Validate(i))
                    ++countValid;
            }

            return countValid;
        }
    }
}
