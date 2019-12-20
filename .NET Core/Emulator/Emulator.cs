using System;
using System.Linq;

namespace TNRD.AdventOfCode.Emulation
{
    public class Emulator
    {
        public delegate void OnOutputChangedDelegate(int previous, int current);

        public event OnOutputChangedDelegate OnOutputChangedEvent;

        public int[] Memory { get; private set; }
        private int pointer = 0;

        private int[] inputs;
        private int currentInputIndex = 0;

        public int Output { get; private set; }

        public Emulator(params int[] inputs)
        {
            this.inputs = inputs;
        }

        public void Run(string input)
        {
            Memory = ConvertInputToMemory(input);

            for (; pointer < Memory.Length;)
            {
                int value = Memory[pointer];

                try
                {
                    IProgram program = ProgramFactory.CreateProgram(this, value);
                    IParameter[] parameters = new IParameter[program.RequiredParameterCount];

                    for (int i = 1; i <= program.RequiredParameterCount; i++)
                    {
                        int parameterValue = Memory[pointer + i];
                        IParameter parameter = ParameterFactory.CreateParameter(this, value, i, parameterValue);
                        parameters[i - 1] = parameter;
                    }

                    program.Run(parameters);

                    pointer += program.RequiredParameterCount + 1;
                }
                catch (HaltException)
                {
                    break;
                }
                catch (ForceToNextInstructionException)
                {
                }
            }
        }

        private int[] ConvertInputToMemory(string input)
        {
            string[] splits = input.Split(',');
            return splits.Select(int.Parse).ToArray();
        }

        public int GetValueAt(int pointer)
        {
            return Memory[pointer];
        }

        public void WriteValueTo(int pointer, int value)
        {
            Memory[pointer] = value;
        }

        public int GetInput()
        {
            int input = inputs[currentInputIndex];
            ++currentInputIndex;
            return input;
        }

        public void WriteToOutput(int value)
        {
            int previous = Output;
            Output = value;
            OnOutputChangedEvent?.Invoke(previous, Output);
        }

        public void JumpAhead(int amount)
        {
            pointer += amount;
        }

        public void JumpTo(int value)
        {
            pointer = value;
        }
    }
}
