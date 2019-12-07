namespace TNRD.AdventOfCode.DaySix.Shared
{
    public class Planet
    {
        public readonly string Key;
        public Planet OrbitingPlanet;

        public Planet(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return $"{Key} | {OrbitingPlanet?.Key ?? "NULL"}";
        }
    }
}
