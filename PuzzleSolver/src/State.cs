using System.Collections.Generic;

namespace PuzzleSolver
{
    public class State
    {
        public Board Board { get; private set; }
        public int CurrentCost { get; }
        public int EstimatedRemainingCost { get; }
        public int Cost => CurrentCost + EstimatedRemainingCost;
        public List<State> ChildStates { get; } = new List<State>();
        public bool IsExpanded { get; set; } = false;
        public State(Board board, int currentCost, int estimatedRemainingCost)
        {
            Board = board;
            CurrentCost = currentCost;
            EstimatedRemainingCost = estimatedRemainingCost;
        }
    }
}
