using System.Collections.Generic;

namespace TNRD.AdventOfCode.DaySix.Shared
{
    public class Galaxy
    {
        private Dictionary<string, Planet> keyToPlanet = new Dictionary<string, Planet>();

        public IEnumerable<Planet> Planets => keyToPlanet.Values;

        public void Add(Planet planet)
        {
            keyToPlanet.TryAdd(planet.Key, planet);

            if (planet.OrbitingPlanet != null)
                Add(planet.OrbitingPlanet);
        }

        public bool Contains(string key)
        {
            return keyToPlanet.ContainsKey(key);
        }

        public bool TryGet(string key, out Planet planet)
        {
            return keyToPlanet.TryGetValue(key, out planet);
        }

        public Planet Get(string key)
        {
            return keyToPlanet[key];
        }
    }
}
