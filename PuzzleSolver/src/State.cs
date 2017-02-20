using System.Collections.Generic;

namespace PuzzleSolver
{
    public class State
    {
        public Board Board { get; private set; }
        public int CurrentCost { get; }
        public int EstimatedRemainingCost { get; }
        private const double Weight = 1.2;
        public double Cost
        {
            get
            {
                switch (EstimationMethod)
                {
                    case CostEstimationMethod.Astar:
                        return CurrentCost + EstimatedRemainingCost;
                    case CostEstimationMethod.Wa:
                        return CurrentCost + Weight * EstimatedRemainingCost;
                    case CostEstimationMethod.GreedyBestFirst:
                        return EstimatedRemainingCost;
                }

                return CurrentCost + Weight * EstimatedRemainingCost;
            }
        }

        public List<State> ChildStates { get; } = new List<State>();
        public bool IsExpanded { get; set; } = false;
        private CostEstimationMethod EstimationMethod { get; }
        public State(Board board, CostEstimationMethod costEstimationMethod, int currentCost, int estimatedRemainingCost)
        {
            Board = board;
            CurrentCost = currentCost;
            EstimatedRemainingCost = estimatedRemainingCost;
            EstimationMethod = costEstimationMethod;
        }
    }
}
