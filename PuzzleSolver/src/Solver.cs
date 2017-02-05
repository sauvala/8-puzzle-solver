using System;
using System.Linq;

namespace PuzzleSolver
{
    public class Solver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Solver is running");
            var board = new Board(3);
            Console.WriteLine("Board initial state: " + Environment.NewLine + board.PrintState());
            var initialCostEstimate = CostEstimator.EstimateCost(board);
            Console.WriteLine("Cost estimation: " + initialCostEstimate + Environment.NewLine);

            if (initialCostEstimate == 0)
            {
                Console.WriteLine("Initial state was already the goal state. Exiting from the program.");
                Environment.Exit(0);
            }
            
            BoardMover.MoveTiles(board);
            Console.WriteLine("Reachable states:" + Environment.NewLine);
            var nextStates = BoardMover.MoveTiles(board);
            foreach (var boardState in nextStates)
            {
                Console.WriteLine(boardState.PrintState());
                Console.WriteLine("Estimated cost: " + CostEstimator.EstimateCost(boardState) + Environment.NewLine);
            }
        }
    }
}
