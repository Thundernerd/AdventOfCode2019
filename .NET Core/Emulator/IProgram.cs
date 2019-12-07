namespace TNRD.AdventOfCode.Emulator
{
    public interface IProgram
    {
        public int OpCode { get; }
        public int RequiredParameterCount { get; }

        public void Run(IParameter[] parameters);
    }
}
