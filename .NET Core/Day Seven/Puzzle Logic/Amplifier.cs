using System.Collections.Generic;
using TNRD.AdventOfCode.Emulation;

namespace TNRD.AdventOfCode.DaySeven.Shared
{
    public class Amplifier
    {
        public Emulator Emulator { get; private set; }

        public Queue<int> Output => Emulator.Output;

        public Status Status => Emulator.Status;

        public Amplifier(int phaseSetting)
        {
            Emulator = new Emulator(phaseSetting);
        }

        public Amplifier(int phaseSetting, int input)
        {
            Emulator = new Emulator(phaseSetting, input);
        }

        public void Run(string program)
        {
            Emulator.Run(program);
        }
    }
}
