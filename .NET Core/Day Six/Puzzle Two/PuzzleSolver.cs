using System;
using System.Collections.Generic;
using System.Linq;
using TNRD.AdventOfCode.DaySix.Shared;

namespace TNRD.AdventOfCode.DaySix.PuzzleTwo
{
    public class PuzzleSolver : Foundation.PuzzleSolver
    {
        public override int Day => 6;

        private Galaxy galaxy = new Galaxy();

        public override object Solve(string input)
        {
            string[] lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] splits = line.Split(")", StringSplitOptions.RemoveEmptyEntries);

                Planet planet = PlanetFactory.GetPlanet(galaxy, splits[1].Trim(), splits[0].Trim());
                galaxy.Add(planet);
            }

            Planet origin = galaxy.Get("YOU");
            Planet destination = galaxy.Get("SAN");

            return GetShortestPathBetweenPlanets(origin, destination) - 2;
        }

        private int GetShortestPathBetweenPlanets(Planet a, Planet b)
        {
            List<(string, int)> ancestorsA = GetAncestors(a);
            List<(string, int)> ancestorsB = GetAncestors(b);

            List<string> sharedAncestors = ancestorsA.Intersect(ancestorsB, new AncestorComparer())
                .Select(x => x.Item1)
                .ToList();

            List<(string x, int)> orderedDistancesBetweenPlanets = sharedAncestors.Select(x => (x,
                    ancestorsA.First(y => y.Item1 == x).Item2 + ancestorsB.First(y => y.Item1 == x).Item2))
                .OrderBy(x => x.Item2)
                .ToList();

            return orderedDistancesBetweenPlanets.First().Item2;
        }

        private List<(string, int)> GetAncestors(Planet planet)
        {
            List<(string, int)> ancestors = new List<(string, int)>();

            int steps = 1;

            planet = planet.OrbitingPlanet;
            while (planet != null)
            {
                ancestors.Add((planet.Key, steps));
                planet = planet.OrbitingPlanet;
                ++steps;
            }

            return ancestors;
        }

        private class AncestorComparer : IEqualityComparer<(string, int)>
        {
            public bool Equals((string, int) x, (string, int) y)
            {
                return x.Item1.Equals(y.Item1);
            }

            public int GetHashCode((string, int) obj)
            {
                return obj.Item1.GetHashCode();
            }
        }
    }
}
