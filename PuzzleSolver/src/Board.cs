using System;

namespace PuzzleSolver
{
    public class Board
    {
        public int Size { get; }
        public Tile[,] Tiles { get; }
        private const int RowWidth = 3;
        private const int ColumnHeight = 3;
        public Board(int size)
        {
            Size = size;
            Tiles = new Tile[RowWidth, ColumnHeight];
            InitRandomState(Size);
        }

        public string PrintState()
        {
            string state = "";
            for (var row = 0; row < RowWidth; row++)
            {
                for (var column = 0; column < ColumnHeight; column++)
                {
                    state += "|" + Tiles[row, column].ToString();

                    if (column == ColumnHeight - 1)
                    {
                        state += "|" + Environment.NewLine;
                    }
                }
            }

            return state;
        }

        private void InitRandomState(int size)
        {
            SetInitialState(size);
            ShuffleState();
        }
        private void SetInitialState(int size)
        {
            var tileNumber = 1;
            for (var row = 0; row < RowWidth; row++)
            {
                for (var column = 0; column < ColumnHeight; column++)
                {
                    if (tileNumber <= size)
                    {
                        Tiles[row, column] = new Tile(tileNumber);
                        tileNumber++;
                    }
                    else
                    {
                        Tiles[row, column] = new Tile(null);
                    }
                }
            }
        }
        private void ShuffleState()
        {
            var random = new Random();
            for (var row = 0; row < RowWidth; row++)
            {
                for (var column = 0; column < ColumnHeight; column++)
                {
                    var newRowIndex = random.Next(0, RowWidth);
                    var newColumnIndex = random.Next(0, ColumnHeight);
                    var switchTile = Tiles[newRowIndex, newColumnIndex];
                    Tiles[newRowIndex, newColumnIndex] = Tiles[row, column];
                    Tiles[row, column] = switchTile;
                }
            }
        }
    }
}
