using System;
using System.IO;

namespace TNRD.AdventOfCode.Foundation
{
    public class BaseProgram
    {
        private const string SESSION_COOKIE_PATH = "../../../../../session_cookie.txt";

        protected static void CreateAndSolve()
        {
            if (!File.Exists(SESSION_COOKIE_PATH))
            {
                Console.WriteLine("A file containing the session cookie is required to continue.");
                return;
            }

            string sessionCookie = File.ReadAllText(SESSION_COOKIE_PATH);

            IPuzzleSolver solver = PuzzleSolverFactory.Create();
            string input = PuzzleInputDownloader.DownloadInput(solver.Day, sessionCookie);
            object answer = solver.Solve(input);
            Console.WriteLine($"Answer for day {solver.Day} is {answer}");
        }
    }
}
