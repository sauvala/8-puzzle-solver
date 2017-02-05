using System.Collections.Generic;

namespace PuzzleSolver
{
    public static class BoardExpander
    {
        public static IEnumerable<Board> ExpandStates(Board board)
        {
            var newBoardStates = new List<Board>();
            for (var row = 0; row < Board.RowWidth; row++)
            {
                for (var column = 0; column < Board.ColumnHeight; column++)
                {
                    if (board.Tiles[row, column].Number == null) continue;
                    if (column + 1 < Board.RowWidth && board.Tiles[row, column + 1].Number == null)
                    {
                        var newBoard = new Board(board);
                        newBoard.Tiles[row, column + 1] = board.Tiles[row, column];
                        newBoard.Tiles[row, column] = board.Tiles[row, column + 1];
                        newBoardStates.Add(newBoard);
                    }

                    if (column - 1 >= 0 && board.Tiles[row, column - 1].Number == null)
                    {
                        var newBoard = new Board(board);
                        newBoard.Tiles[row, column - 1] = board.Tiles[row, column];
                        newBoard.Tiles[row, column] = board.Tiles[row, column - 1];
                        newBoardStates.Add(newBoard);
                    }

                    if (row + 1 < Board.ColumnHeight && board.Tiles[row + 1, column].Number == null)
                    {
                        var newBoard = new Board(board);
                        newBoard.Tiles[row + 1, column] = board.Tiles[row, column];
                        newBoard.Tiles[row, column] = board.Tiles[row + 1, column];
                        newBoardStates.Add(newBoard);
                    }

                    if (row - 1 >= 0 && board.Tiles[row - 1, column].Number == null)
                    {
                        var newBoard = new Board(board);
                        newBoard.Tiles[row - 1, column] = board.Tiles[row, column];
                        newBoard.Tiles[row, column] = board.Tiles[row - 1, column];
                        newBoardStates.Add(newBoard);
                    }
                }
            }

            return newBoardStates;
        }
    }
}
