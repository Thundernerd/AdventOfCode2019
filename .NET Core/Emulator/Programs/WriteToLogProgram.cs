namespace TNRD.AdventOfCode.Emulator.Programs
{
    public class WriteToLogProgram : Program
    {
        public WriteToLogProgram(Emulator emulator) : base(emulator)
        {
        }

        public override int OpCode => 4;

        public override int RequiredParameterCount => 1;

        public override void Run(IParameter[] parameters)
        {
            Emulator.WriteToOutput(parameters[0].GetValue());
        }
    }
}
