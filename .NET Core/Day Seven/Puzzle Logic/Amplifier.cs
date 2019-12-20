using TNRD.AdventOfCode.Emulation;

namespace TNRD.AdventOfCode.DaySeven.Shared
{
    public class Amplifier
    {
        private readonly int phaseSetting;
        private readonly int input;

        private Emulator emulator;

        public int Output { get; private set; }

        public Amplifier(int phaseSetting, int input)
        {
            this.phaseSetting = phaseSetting;
            this.input = input;

            emulator = new Emulator(phaseSetting, input);
        }

        public void Run(string program)
        {
            emulator.Run(program);
            Output = emulator.Output;
        }
    }
}
