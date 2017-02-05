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
            var costEstimationType = CostEstimationType.Wa;
            var initialBoard = new Board(8);
            var initialCostEstimate = CostEstimator.EstimateCost(initialBoard);

            if (initialCostEstimate == 0)
            {
                Console.WriteLine("Initial state was already the goal state. Exiting from the program.");
                Environment.Exit(0);
            }

            var state = new State(initialBoard, costEstimationType, 0, initialCostEstimate);
            var searchableStates = new Dictionary<string, State> { { state.Board.ToString(), state } };
            var round = 0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            while (true)
            {
                round++;
                state.IsExpanded = true;
                Console.WriteLine("Search Round: " + round + Environment.NewLine);
                Console.WriteLine("State: " + Environment.NewLine + Environment.NewLine + state.Board);
                Console.WriteLine("Current cost: " + state.CurrentCost);
                Console.WriteLine("Estimated remaining cost: " + state.EstimatedRemainingCost + Environment.NewLine);

                if (state.EstimatedRemainingCost == 0)
                {
                    stopWatch.Stop();
                    var timeSpan = stopWatch.Elapsed;
                    Console.WriteLine(Environment.NewLine + "Goal state found!" + Environment.NewLine);
                    Console.WriteLine(state.Board + Environment.NewLine);
                    Console.WriteLine("Number of expanded nodes: " + searchableStates.Count);
                    Console.WriteLine("Elapsed time: " + timeSpan.Seconds + "." + timeSpan.Milliseconds + " seconds" + Environment.NewLine);
                    return;
                }

                Console.WriteLine("Reachable states:" + Environment.NewLine);
                var childStates = BoardExpander.ExpandStates(state.Board);

                foreach (var child in childStates)
                {
                    Console.WriteLine(child.ToString());
                    var remainingCost = CostEstimator.EstimateCost(child);
                    var childState = new State(child, costEstimationType,  state.CurrentCost + 1, remainingCost);
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