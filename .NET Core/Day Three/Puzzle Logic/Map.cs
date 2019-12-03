using System.Collections.Generic;
using System.Linq;

namespace TNRD.AdventOfCode.DayThree.Shared
{
    public class Map
    {
        private readonly Dictionary<(int, int), int> positionToLength = new Dictionary<(int, int), int>();

        private int length;

        public List<(int, int)> Positions => positionToLength.Keys.ToList();

        public Dictionary<(int, int), int> PositionToLength => positionToLength;

        public void Add(int x, int y)
        {
            positionToLength.TryAdd((x, y), ++length);
        }
    }
}
