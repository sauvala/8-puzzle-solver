using System;

namespace PuzzleSolver
{
    public class Tile
    {
        public int? Number { get; }
        public override String ToString()
        {
            return Number == null ? "0" : Number.ToString();
        }
        public Tile(int? tileNumber)
        {
            Number = tileNumber;
        }
    }
}
