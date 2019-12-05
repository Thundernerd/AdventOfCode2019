namespace TNRD.AdventOfCode.DayFive.Shared.Programs
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
            Emulator.WriteToLog(parameters[0].GetValue());
        }
    }
}
