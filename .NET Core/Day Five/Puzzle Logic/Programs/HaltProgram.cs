namespace TNRD.AdventOfCode.DayFive.Shared.Programs
{
    public class HaltProgram : Program
    {
        public HaltProgram(Emulator emulator) : base(emulator)
        {
        }

        public override int OpCode => 99;

        public override int RequiredParameterCount => 0;

        public override void Run(IParameter[] parameters)
        {
            throw new HaltException();
        }
    }
}
