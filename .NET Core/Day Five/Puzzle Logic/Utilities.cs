using System;

namespace TNRD.AdventOfCode.DayFive.Shared
{
    public class Utilities
    {
        public static int GetDigitFromInteger(int number, int digitFromRight)
        {
            if (number.ToString().Length == 1)
                return 0;

            return (number / (int) Math.Pow(10, digitFromRight - 1)) % 10;
        }
    }
}
