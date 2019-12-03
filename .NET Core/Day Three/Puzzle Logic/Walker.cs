using System;
using System.Numerics;

namespace TNRD.AdventOfCode.DayThree.Shared
{
    public class Walker
    {
        private readonly string input;
        private readonly Map map = new Map();

        public Map Map => map;

        public Walker(string input)
        {
            this.input = input;
        }

        public void Walk()
        {
            int x = 0;
            int y = 0;

            string[] splits = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            foreach (var split in splits)
            {
                char direction = split[0];
                int count = int.Parse(split.Substring(1));

                for (int i = 0; i < count; i++)
                {
                    switch (direction)
                    {
                        case 'U':
                            ++y;
                            break;
                        case 'D':
                            --y;
                            break;
                        case 'L':
                            --x;
                            break;
                        case 'R':
                            ++x;
                            break;
                    }

                    map.Add(x, y);
                }
            }
        }
    }
}
