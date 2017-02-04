using System.Dynamic;

namespace PuzzleSolver.src
{
    public class Board
    {
        public Board(int size)
        {
            Size = size;
            Tiles = new Tile[size];
        }
        public int Size { get; }
        public Tile[] Tiles { get; }
    }
}
