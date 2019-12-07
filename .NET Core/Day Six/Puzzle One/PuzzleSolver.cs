using System;
using System.Linq;
using TNRD.AdventOfCode.DaySix.Shared;

namespace TNRD.AdventOfCode.DaySix.PuzzleOne
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

                Planet planet = PlanetFactory.GetPlanet(galaxy, splits[1], splits[0]);
                galaxy.Add(planet);
            }

            int totalOrbits = galaxy.Planets.Sum(CalculateOrbits);
            return totalOrbits;
        }

        private int CalculateOrbits(Planet planet)
        {
            int orbits = 0;

            while (planet != null)
            {
                if (planet.OrbitingPlanet != null)
                {
                    ++orbits;
                }

                planet = planet.OrbitingPlanet;
            }

            return orbits;
        }
    }
}
