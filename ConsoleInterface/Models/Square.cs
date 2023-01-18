namespace ConsoleInterface.Models;

public class Square
{
    public char X { get; set; }
    public char Y { get; set; }
    public SquareType Type { get; set; }
}

public enum SquareType
{
    Empty,
    Ship,
    ShotEmpty,
    ShotShip
}