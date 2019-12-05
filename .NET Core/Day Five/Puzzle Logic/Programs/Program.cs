namespace TNRD.AdventOfCode.DayFive.Shared.Programs
{
    public abstract class Program : IProgram
    {
        public abstract int OpCode { get; }
        public abstract int RequiredParameterCount { get; }

        protected readonly Emulator Emulator;

        public Program(Emulator emulator)
        {
            Emulator = emulator;
        }

        public abstract void Run(IParameter[] parameters);
    }
}
