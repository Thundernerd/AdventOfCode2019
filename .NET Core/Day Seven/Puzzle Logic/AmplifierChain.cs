using System.Collections.Generic;
using System.Linq;
using TNRD.AdventOfCode.Emulation;

namespace TNRD.AdventOfCode.DaySeven.Shared
{
    public class AmplifierChain
    {
        private readonly string program;

        public string PhaseSettings { get; private set; }
        public int Output { get; private set; }

        public AmplifierChain(string phaseSettings, string program)
        {
            this.program = program;
            PhaseSettings = phaseSettings;
        }

        public void Run()
        {
            List<Amplifier> chain = CreateChain();

            Queue<int> input = new Queue<int>();
            input.Enqueue(0);

            do
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    Amplifier amplifier = chain[i];
                    amplifier.Run(program);

                    if (amplifier.Status == Status.WaitingForInput && input.Count > 0)
                    {
                        amplifier.Emulator.AddInput(input.Dequeue());
                        amplifier.Run(null);
                    }

                    while (amplifier.Output.Count > 0)
                    {
                        input.Enqueue(amplifier.Output.Dequeue());
                    }
                }
            } while (chain.Any(x => x.Status == Status.WaitingForInput));

            // Last output is enqueued into input so we can use that here
            Output = input.Dequeue();
        }

        private List<Amplifier> CreateChain()
        {
            List<Amplifier> chain = new List<Amplifier>();

            for (var i = 0; i < PhaseSettings.Length; i++)
            {
                char setting = PhaseSettings[i];
                int phaseSetting = int.Parse(setting.ToString());
                Amplifier amplifier = new Amplifier(phaseSetting);
                chain.Add(amplifier);
            }

            return chain;
        }
    }
}
