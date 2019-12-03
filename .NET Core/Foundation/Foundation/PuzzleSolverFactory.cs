using System;
using System.Reflection;

namespace TNRD.AdventOfCode.Foundation
{
    public class PuzzleSolverFactory
    {
        public static IPuzzleSolver Create()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (!ValidateType(type))
                        continue;

                    return (IPuzzleSolver) Activator.CreateInstance(type);
                }
            }

            return null;
        }

        private static bool ValidateType(Type type)
        {
            if (!type.IsSubclassOf(typeof(PuzzleSolver)))
                return false;

            if (type.IsAbstract)
                return false;

            return true;
        }
    }
}
