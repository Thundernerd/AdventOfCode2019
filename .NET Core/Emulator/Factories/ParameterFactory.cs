using System;
using System.Collections.Generic;
using System.Reflection;

namespace TNRD.AdventOfCode.Emulation
{
    public static class ParameterFactory
    {
        private static Dictionary<int, Type> modeToParameterType = new Dictionary<int, Type>();

        static ParameterFactory()
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

                    if (!typeof(IParameter).IsAssignableFrom(type))
                        continue;

                    IParameter instance = (IParameter) Activator.CreateInstance(type, null, 0);
                    modeToParameterType.Add(instance.Mode, type);
                }
            }
        }

        public static IParameter CreateParameter(Emulator emulator, int opCode, int index, int value)
        {
            int digit = Utilities.GetDigitFromInteger(opCode, index + 2);
            return (IParameter) Activator.CreateInstance(modeToParameterType[digit], emulator, value);
        }


    }
}
