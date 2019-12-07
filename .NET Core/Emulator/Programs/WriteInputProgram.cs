namespace TNRD.AdventOfCode.Emulator.Programs
{
    public class WriteInputProgram : Program
    {
        public WriteInputProgram(Emulator emulator) : base(emulator)
        {
        }

        public override int OpCode => 3;

        public override int RequiredParameterCount => 1;

        public override void Run(IParameter[] parameters)
        {
            Emulator.WriteValueTo(parameters[0].RawValue, Emulator.GetInput());
        }
    }
}
