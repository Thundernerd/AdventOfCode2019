using System;
using System.Collections.Generic;
using System.Linq;

namespace TNRD.AdventOfCode.DayTwo.Shared
{
    public static class InputConverter
    {
        public static List<int> CreateMemory(string input)
        {
            return CreateMemory(input, 12, 2);
        }

        public static List<int> CreateMemory(string input, int noun, int verb)
        {
            string[] splits = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
            List<int> convertedInput = splits.Select(int.Parse).ToList();
            convertedInput[1] = noun;
            convertedInput[2] = verb;
            return convertedInput;
        }
    }
}
