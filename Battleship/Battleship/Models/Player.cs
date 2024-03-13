namespace Battleship.Models
{
    public class Player
    {
        public IEnumerable<IEnumerable<(int X, int Y)>> MyShips { get; set; }
        public bool[,] TakenShots { get; set; }
        public int NumberOfSunkShips { get; set; }

        public void MarkShot((int X, int Y) coordinates)
        {
            TakenShots[coordinates.X, coordinates.Y] = true;
        }

        public void IncrementSunkShips()
        {
            NumberOfSunkShips++;
        }
    }
}
