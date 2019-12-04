namespace TNRD.AdventOfCode.DayFour.Shared
{
    public class DuplicateAdjacentDigitsRule : IPasswordRule
    {
        private readonly int duplicateAmount;

        public DuplicateAdjacentDigitsRule(int duplicateAmount)
        {
            this.duplicateAmount = duplicateAmount;
        }

        public bool Validate(int password)
        {
            string stringified = password.ToString();

            int same = 0;

            for (int i = 1; i < stringified.Length; i++)
            {
                char c = stringified[i];
                char pc = stringified[i - 1];

                if (c != pc)
                {
                    same = 0;
                    continue;
                }

                ++same;

                if (same >= duplicateAmount)
                    return true;
            }

            return false;
        }
    }
}
