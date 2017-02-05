using System;
using System.Linq;

namespace PuzzleSolver
{
    public class Solver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Solver is running");
            var board = new Board(8);
            Console.WriteLine("Board initial state: " + Environment.NewLine + board.PrintState());
            Console.WriteLine("Initial cost estimation: " + CostEstimator.EstimateCost(board));
            BoardMover.MoveTiles(board);
            Console.WriteLine("Reachable states:");
            var nextStates = BoardMover.MoveTiles(board);
            foreach (var boardState in nextStates)
            {
                Console.WriteLine(boardState.PrintState());
            }
        }
    }
}
