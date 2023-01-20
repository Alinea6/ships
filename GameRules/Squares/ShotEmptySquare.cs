namespace GameRules.Squares;

public class ShotEmptySquare : Square
{
    
    public ShotEmptySquare(Coordinate coordinate) : base(coordinate)
    {
        _type = SquareType.ShotEmpty;
    }
}