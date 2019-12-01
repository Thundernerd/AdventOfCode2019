using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TNRD.AOC.DayOne
{
    public class PuzzleSolver
    {
        protected int Day { get; private set; }
        protected string Input { get; private set; }

        private ConcurrentBag<double> individualFuelCalculations = new ConcurrentBag<double>();

        public PuzzleSolver(int day, string sessionCookie)
        {
            Day = day;
            Input = PuzzleInputDownloader.DownloadInput(day, sessionCookie);
        }

        public void Solve()
        {
            string[] lines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            Parallel.ForEach(lines, Calculate);
            double totalRequiredFuel = individualFuelCalculations.AsParallel().Sum();
            Console.WriteLine($"Puzzle answer for day {Day} is {totalRequiredFuel}");
        }

        private void Calculate(string line)
        {
            double value = ConvertLine(line);
            double requiredFuel = CalculateFuel(value);
            individualFuelCalculations.Add(requiredFuel);
        }

        private double ConvertLine(string input)
        {
            if (!double.TryParse(input, out double result))
            {
                throw new ConvertInputException(input);
            }

            return result;
        }

        private double CalculateFuel(double input)
        {
            double result = Math.Floor(input / 3d) - 2;
            return result;
        }

        [Serializable]
        public class ConvertInputException : Exception
        {
            //
            // For guidelines regarding the creation of new exception types, see
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
            // and
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
            //

            private ConvertInputException()
            {
            }

            public ConvertInputException(string message)
                : base($"Unable to convert input '{message}'")
            {
            }

            private ConvertInputException(string message, Exception inner) : base(message, inner)
            {
            }

            protected ConvertInputException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
