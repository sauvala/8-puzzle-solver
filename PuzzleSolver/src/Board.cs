namespace PuzzleSolver.src
{
    public class Board
    {
        public int Size { get; }
        public Tile[,] Tiles { get; }
        public Board(int size)
        {
            Size = size;
            Tiles = new Tile[3, 3];
        }
    }
}
