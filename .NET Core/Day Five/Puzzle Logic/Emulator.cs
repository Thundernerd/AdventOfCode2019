using System;
using System.Linq;

namespace TNRD.AdventOfCode.DayFive.Shared
{
    public class Emulator
    {
        public int[] Memory { get; private set; }
        public int Pointer = 0;

        public Emulator()
        {
        }

        public void Run(string input)
        {
            Memory = ConvertInputToMemory(input);

            for (; Pointer < Memory.Length;)
            {
                int value = Memory[Pointer];

                try
                {
                    IProgram program = ProgramFactory.CreateProgram(this, value);
                    IParameter[] parameters = new IParameter[program.RequiredParameterCount];

                    for (int i = 1; i <= program.RequiredParameterCount; i++)
                    {
                        int parameterValue = Memory[Pointer + i];
                        IParameter parameter = ParameterFactory.CreateParameter(this, value, i, parameterValue);
                        parameters[i - 1] = parameter;
                    }

                    program.Run(parameters);

                    Pointer += program.RequiredParameterCount + 1;
                }
                catch (HaltException)
                {
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
            Console.Write("Expecting input: ");
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        public void WriteToLog(int value)
        {
            Console.WriteLine(value);
        }
    }
}
