namespace TNRD.AdventOfCode.DayFive.Shared.Parameters
{
    public abstract class Parameter : IParameter
    {
        protected readonly Emulator Emulator;
        protected readonly int Value;

        public abstract int Mode { get; }
        public int RawValue => Value;

        protected Parameter(Emulator emulator, int value)
        {
            Emulator = emulator;
            Value = value;
        }

        public abstract int GetValue();
    }
}
