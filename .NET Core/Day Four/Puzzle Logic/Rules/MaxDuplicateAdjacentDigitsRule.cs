using System.Collections.Generic;
using System.Linq;

namespace TNRD.AdventOfCode.DayFour.Shared
{
    public class MaxDuplicateAdjacentDigitsRule : IPasswordRule
    {
        private readonly int maxLength;

        public MaxDuplicateAdjacentDigitsRule(int maxLength)
        {
            this.maxLength = maxLength;
        }

        public bool Validate(int password)
        {
            IncreasingDigitRule increasingRule = new IncreasingDigitRule();
            if (!increasingRule.Validate(password))
                return false;

            string stringified = password.ToString();

            List<int> groups = stringified.GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.ToList().Count)
                .Select(x => x.Value)
                .ToList();

            return groups.Any(x => x == maxLength);
        }
    }
}
