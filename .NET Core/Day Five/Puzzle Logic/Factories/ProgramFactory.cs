using System;
using System.Collections.Generic;
using System.Reflection;

namespace TNRD.AdventOfCode.DayFive.Shared
{
    public static class ProgramFactory
    {
        private static Dictionary<int, Type> opCodeToProgramType = new Dictionary<int, Type>();

        static ProgramFactory()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsAbstract)
                        continue;

                    if (type.IsInterface)
                        continue;

                    if (!typeof(IProgram).IsAssignableFrom(type))
                        continue;

                    IProgram instance = (IProgram) Activator.CreateInstance(type, 
                        new object[] {null});
                    opCodeToProgramType.Add(instance.OpCode, type);
                }
            }
        }

        public static IProgram CreateProgram(Emulator emulator, int value)
        {
            if (value.ToString().Length != 1)
                value = Utilities.GetDigitFromInteger(value, 2) * 10 + Utilities.GetDigitFromInteger(value, 1);
            
            return (IProgram) Activator.CreateInstance(opCodeToProgramType[value], emulator);
        }
    }
}
