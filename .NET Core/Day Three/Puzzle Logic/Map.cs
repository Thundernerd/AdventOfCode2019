using System.Collections.Generic;

namespace TNRD.AdventOfCode.DayThree.Shared
{
    public class Map
    {
        private List<(int, int)> positions = new List<(int, int)>();

        public List<(int, int)> Positions => positions;

        public void Add(int x, int y)
        {
            positions.Add((x, y));
        }
    }
}
