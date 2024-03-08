﻿namespace Battleship.Models
{
    public class ShipPosition
    {
        public (int X, int Y) Coordinates { get; set; }
        public int Size { get; set; }
        public Orientation Orientation { get; set; }
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
}
