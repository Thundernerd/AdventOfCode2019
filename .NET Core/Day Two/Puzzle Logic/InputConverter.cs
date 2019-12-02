using System;
using System.Collections.Generic;
using System.Linq;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public static class InputConverter
    {
        public static List<int> ConvertToIntegers(string input)
        {
            string[] splits = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
            List<int> convertedInput = splits.Select(int.Parse).ToList();
            convertedInput[1] = 12;
            convertedInput[2] = 2;
            return convertedInput;
        }
    }
}
