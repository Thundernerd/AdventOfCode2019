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

        public void Run(int input = 0)
        {
            for (var i = 0; i < PhaseSettings.Length; i++)
            {
                char setting = PhaseSettings[i];
                int phaseSetting = int.Parse(setting.ToString());

                Amplifier amplifier = new Amplifier(phaseSetting, input);
                amplifier.Run(program);
                input = amplifier.Output;
            }

            Output = input;
        }
    }
}
