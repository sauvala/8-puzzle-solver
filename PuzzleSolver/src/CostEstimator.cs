using System;

namespace PuzzleSolver
{
    public static class CostEstimator
    {
        public static int EstimateCost(Board board)
        {
            var costEstimation = 0;
            for (var row = 0; row < Board.RowWidth; row++)
            {
                for (var column = 0; column < Board.ColumnHeight; column++)
                {
                    var number = board.Tiles[row, column].Number;
                    if (number == null) continue;
                    var correctPlacementInBoard = GetCorrectBoardIndexes(board.Tiles[row, column]);
                    if (correctPlacementInBoard == null) continue;
                    var rowDistance = Math.Abs(row - correctPlacementInBoard.Item1);
                    var columnDistance = Math.Abs(column - correctPlacementInBoard.Item2);
                    costEstimation += rowDistance + columnDistance;
                }
            }
            return costEstimation;
        }

        private static Tuple<int, int> GetCorrectBoardIndexes(Tile tile)
        {
            switch (tile.Number)
            {
                case 1:
                    return new Tuple<int, int>(0, 0);
                case 2:
                    return new Tuple<int, int>(0, 1);
                case 3:
                    return new Tuple<int, int>(0, 2);
                case 4:
                    return new Tuple<int, int>(1, 0);
                case 5:
                    return new Tuple<int, int>(1, 1);
                case 6:
                    return new Tuple<int, int>(1, 2);
                case 7:
                    return new Tuple<int, int>(2, 0);
                case 8:
                    return new Tuple<int, int>(2, 1);
                default:
                    return null;
            }
        }
    }
}
