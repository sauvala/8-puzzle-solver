using System.Dynamic;

namespace PuzzleSolver.src
{
    public class Board
    {
        public Board(int size)
        {
            Size = size;
            Tiles = new Tile[3, 3];
        }

        public int Size { get; }
        public Tile[,] Tiles { get; }
    }
}
