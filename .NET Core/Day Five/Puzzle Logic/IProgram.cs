namespace TNRD.AdventOfCode.DayFive.Shared
{
    public interface IProgram
    {
        public int OpCode { get; }
        public int RequiredParameterCount { get; }

        public void Run(IParameter[] parameters);
    }
}
