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
                switch (EstimationType)
                {
                    case CostEstimationType.A:
                        return CurrentCost + EstimatedRemainingCost;
                    case CostEstimationType.GreedyBestFirst:
                        return EstimatedRemainingCost;
                }

                return CurrentCost + Weight * EstimatedRemainingCost;
            }
        }

        public List<State> ChildStates { get; } = new List<State>();
        public bool IsExpanded { get; set; } = false;
        private CostEstimationType EstimationType { get; }
        public State(Board board, CostEstimationType costEstimationType, int currentCost, int estimatedRemainingCost)
        {
            Board = board;
            CurrentCost = currentCost;
            EstimatedRemainingCost = estimatedRemainingCost;
            EstimationType = costEstimationType;
        }
    }
}
