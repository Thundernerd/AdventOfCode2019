namespace TNRD.AdventOfCode.DayFive.Shared.Programs
{
    public class EqualsProgram : Program
    {
        public EqualsProgram(Emulator emulator) : base(emulator)
        {
        }

        public override int OpCode => 8;

        public override int RequiredParameterCount => 3;

        public override void Run(IParameter[] parameters)
        {
            int value = parameters[0].GetValue() == parameters[1].GetValue() ? 1 : 0;
            Emulator.WriteValueTo(parameters[2].RawValue, value);
        }
    }
}
