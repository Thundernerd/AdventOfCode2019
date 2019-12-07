namespace TNRD.AdventOfCode.Emulator.Programs
{
    public class JumpIfFalseProgram : Program
    {
        public JumpIfFalseProgram(Emulator emulator) : base(emulator)
        {
        }

        public override int OpCode => 6;

        public override int RequiredParameterCount => 2;

        public override void Run(IParameter[] parameters)
        {
            int first = parameters[0].GetValue();
            if (first != 0)
                return;

            Emulator.JumpTo(parameters[1].GetValue());
            throw new ForceToNextInstructionException();
        }
    }
}
