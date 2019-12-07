namespace TNRD.AdventOfCode.Emulator.Programs
{
    public class JumpIfTrueProgram : Program
    {
        public JumpIfTrueProgram(Emulator emulator) : base(emulator)
        {
        }

        public override int OpCode => 5;

        public override int RequiredParameterCount => 2;

        public override void Run(IParameter[] parameters)
        {
            int value = parameters[0].GetValue();
            if (value == 0)
                return;
            
            Emulator.JumpTo(parameters[1].GetValue());
            throw new ForceToNextInstructionException();
        }
    }
}
