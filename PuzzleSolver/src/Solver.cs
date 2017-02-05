using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PuzzleSolver
{
    public class Solver
    {
        public static void Main(string[] args)
        {
            var initialBoard = new Board(8);
            var initialCostEstimate = CostEstimator.EstimateCost(initialBoard);

            if (initialCostEstimate == 0)
            {
                Console.WriteLine("Initial state was already the goal state. Exiting from the program.");
                Environment.Exit(0);
            }

            var state = new State(initialBoard, 0, initialCostEstimate);
            var searchableStates = new Dictionary<string, State> { { state.Board.ToString(), state } };
            var isSolved = false;
            var round = 0;
            while (isSolved == false)
            {
                round++;
                state.IsExpanded = true;
                Console.WriteLine("Search Round: " + round + Environment.NewLine);
                Console.WriteLine("State: " + Environment.NewLine + Environment.NewLine + state.Board);
                Console.WriteLine("Current cost: " + state.CurrentCost);
                Console.WriteLine("Estimated remaining cost: " + state.EstimatedRemainingCost + Environment.NewLine);
                Console.WriteLine("Reachable states:" + Environment.NewLine);
                var childStates = BoardExpander.ExpandStates(state.Board);

                foreach (var child in childStates)
                {
                    Console.WriteLine(child.ToString());
                    var remainingCost = CostEstimator.EstimateCost(child);

                    if (remainingCost == 0)
                    {
                        Console.WriteLine("Goal state found!");
                        Console.WriteLine(child + Environment.NewLine);
                        Console.WriteLine("Number of expanded nodes: " + searchableStates.Count + Environment.NewLine);
                        isSolved = true;
                    }

                    var childState = new State(child, state.CurrentCost + 1, remainingCost);
                    Console.WriteLine("Current cost: " + childState.CurrentCost);
                    Console.WriteLine("Estimated remaining cost: " + childState.EstimatedRemainingCost);
                    Console.WriteLine("Total cost: " + childState.Cost + Environment.NewLine);
                    state.ChildStates.Add(childState);

                    if (!searchableStates.ContainsKey(childState.Board.ToString()))
                    {
                        searchableStates.Add(childState.Board.ToString(), childState);
                    }
                }

                state = searchableStates.OrderBy(k => k.Value.Cost).FirstOrDefault(x => x.Value.IsExpanded == false).Value;
            }
        }
    }
}