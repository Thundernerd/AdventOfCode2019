namespace TNRD.AdventOfCode.Emulator
{
    public interface IParameter
    {
        public int Mode { get; }
        int RawValue { get; }
        int GetValue();
    }
}
