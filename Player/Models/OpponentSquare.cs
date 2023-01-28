namespace Player.Models;

public class OpponentSquare
{
    public char X { get; set; }
    public char Y { get; set; }
    public OpponentSquareType Type { get; set; }
}

public enum OpponentSquareType
{
    Empty,
    ShotEmpty,
    ShotShip
}