namespace TNRD.AdventOfCode.DayFive.Shared
{
    public interface IParameter
    {
        public int Mode { get; }
        int RawValue { get; }
        int GetValue();
    }
}
