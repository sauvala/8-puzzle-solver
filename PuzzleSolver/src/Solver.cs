using System;

namespace PuzzleSolver
{
    public class Solver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Solver is running");
            var board = new Board(8);
            Console.WriteLine("Board initial state: " + Environment.NewLine + board.PrintState());
        }
    }
}
