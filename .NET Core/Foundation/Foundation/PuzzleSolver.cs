using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TNRD.AdventOfCode.Foundation
{
    public abstract class PuzzleSolver
    {
        protected int Day { get; }
        protected string Input { get; }

        public PuzzleSolver(int day, string sessionCookie)
        {
            Day = day;
            Input = PuzzleInputDownloader.DownloadInput(day, sessionCookie);
        }

        public abstract void Solve();

        public static void Solve(int day)
        {
            if (!File.Exists("session_cookie.txt"))
            {
                Console.WriteLine("A file containing the session cookie is required to continue.");
                return;
            }

            string sessionCookie = File.ReadAllText("session_cookie.txt");

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                ParallelQuery<Type> types = assembly.GetTypes().AsParallel();
                Parallel.ForEach(types, type =>
                {
                    bool isValid = ValidateType(type);
                    if (!isValid)
                        return;

                    PuzzleSolver instance = (PuzzleSolver) Activator.CreateInstance(type, day, sessionCookie);
                    instance.Solve();
                });
            }
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
