using NUnit.Framework;
using TNRD.AdventOfCode.Foundation;

namespace TNRD.AdventOfCode.DaySix.PuzzleTwo
{
    public class Tests : BaseTest
    {
        [Test]
        public void TestOne()
        {
            ExecuteTest(@"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN",4);
        }
    }
}
