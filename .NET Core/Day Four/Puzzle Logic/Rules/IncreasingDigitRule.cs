namespace TNRD.AdventOfCode.DayFour.Shared
{
    public class IncreasingDigitRule : IPasswordRule
    {
        public bool Validate(int password)
        {
            string stringified = password.ToString();

            for (int i = 1; i < stringified.Length; i++)
            {
                char c = stringified[i];
                char pc = stringified[i - 1];

                if (int.Parse(pc.ToString()) > int.Parse(c.ToString()))
                    return false;
            }

            return true;
        }
    }
}
