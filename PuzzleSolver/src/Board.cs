using System;
using System.Linq;

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
            for (var row = 0; row < RowWidth - 1; row++)
            {
                for (var column = 0; column < ColumnHeight - 1; column++)
                {
                    var newRowIndex = random.Next(0, RowWidth);
                    var newColumnIndex = random.Next(0, ColumnHeight );
                    var switchTile = Tiles[newRowIndex, newColumnIndex];
                    Tiles[newRowIndex, newColumnIndex] = Tiles[row, column];
                    Tiles[row, column] = switchTile;
                }
            }
        }
        public string Print()
        {
            string result = "";
            foreach (Tile tile in Tiles)
            {
                result = tile?.Number == null ? result + "0" : result + tile?.Number;
            }
                
            return result;
        }
    }
}
