namespace TNRD.AdventOfCode.Emulator.Parameters
{
    public class ImmediateParameter : Parameter
    {
        public ImmediateParameter(Emulator emulator, int value) : base(emulator, value)
        {
        }

        public override int Mode => 1;

        public override int GetValue()
        {
            return Value;
        }
    }
}
