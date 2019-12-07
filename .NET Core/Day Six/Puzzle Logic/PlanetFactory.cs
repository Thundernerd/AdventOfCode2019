namespace TNRD.AdventOfCode.DaySix.Shared
{
    public class PlanetFactory
    {
        public static Planet GetPlanet(Galaxy galaxy, string key, string orbitingKey)
        {
            if (galaxy.TryGet(key, out Planet planet))
            {
                if (!string.IsNullOrEmpty(orbitingKey))
                {
                    planet.OrbitingPlanet = GetPlanet(galaxy, orbitingKey, null);
                }

                return planet;
            }

            Planet newPlanet = new Planet(key);

            if (!string.IsNullOrEmpty(orbitingKey))
            {
                newPlanet.OrbitingPlanet = GetPlanet(galaxy, orbitingKey, null);
            }

            return newPlanet;
        }
    }
}
