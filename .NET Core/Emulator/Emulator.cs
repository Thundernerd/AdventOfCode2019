using System;
using System.Collections.Generic;
using System.Linq;

namespace TNRD.AdventOfCode.Emulation
{
    public class Emulator
    {
        public delegate void OnOutputAddedDelegate(int value);

        public delegate void OnInputRequiredDelegate();

        public event OnOutputAddedDelegate OnOutputAddedEvent;

        public event OnInputRequiredDelegate OnInputRequiredEvent;

        public int[] Memory { get; private set; }
        private int pointer = 0;

        private Queue<int> inputs;

        public Queue<int> Output { get; private set; } = new Queue<int>();

        public Status Status { get; set; }

        public Emulator(params int[] inputs)
        {
            this.inputs = new Queue<int>(inputs);
        }

        public void Run(string input)
        {
            Status = Status.Executing;

            Output.Clear();
            if (!string.IsNullOrEmpty(input))
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
                    Status = Status.Completed;
                    break;
                }
                catch (ForceToNextInstructionException)
                {
                }
                catch (RequiresInputException)
                {
                    Status = Status.WaitingForInput;
                    OnInputRequiredEvent?.Invoke();
                    break;
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
            if (!HasInput())
            {
                throw new RequiresInputException();
            }

            return inputs.Dequeue();
        }

        public bool HasInput()
        {
            return inputs.Count > 0;
        }

        public void WriteToOutput(int value)
        {
            Output.Enqueue(value);
            OnOutputAddedEvent?.Invoke(value);
        }

        public void JumpAhead(int amount)
        {
            pointer += amount;
        }

        public void JumpTo(int value)
        {
            pointer = value;
        }

        public void AddInput(int input)
        {
            inputs.Enqueue(input);
        }
    }
}
