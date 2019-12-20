namespace TNRD.AdventOfCode.Emulation
{
    public interface IParameter
    {
        public int Mode { get; }
        int RawValue { get; }
        int GetValue();
    }
}
