using System;
using System.IO;

namespace TNRD.AOC.DayOne
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("session_cookie.txt"))
            {
                Console.WriteLine("A file with your session cookie is required to continue.");
                return;
            }

            string sessionCookie = File.ReadAllText("session_cookie.txt");
            
            PuzzleSolver puzzleSolver = new PuzzleSolver(1, sessionCookie);
            puzzleSolver.Solve();
        }
    }
}
