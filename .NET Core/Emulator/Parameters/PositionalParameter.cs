namespace TNRD.AdventOfCode.Emulation.Parameters
{
    public class PositionalParameter : Parameter
    {
        public PositionalParameter(Emulator emulator, int value) : base(emulator, value)
        {
        }

        public override int Mode => 0;

        public override int GetValue()
        {
            return Emulator.GetValueAt(Value);
        }
    }
}
