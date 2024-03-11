namespace Battleship.Models
{
    public class Shot
    {
        public (int X, int Y) Coordinates { get; set; }
        public ShotResult Result { get; set; }
    }

    public enum ShotResult
    {
        Miss,
        Hit,
        Sunk
    }
}
