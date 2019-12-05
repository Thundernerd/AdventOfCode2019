namespace TNRD.AdventOfCode.DayFive.Shared.Programs
{
    public class MultiplicationProgram : Program
    {
        public MultiplicationProgram(Emulator emulator) : base(emulator)
        {
        }

        public override int OpCode => 2;

        public override int RequiredParameterCount => 3;

        public override void Run(IParameter[] parameters)
        {
            int calculated = parameters[0].GetValue() * parameters[1].GetValue();
            int pointer = parameters[2].RawValue;
            Emulator.WriteValueTo(pointer, calculated);
        }
    }
}
