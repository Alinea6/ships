namespace GameRules.Squares;

public class EmptySquare : Square
{
    private Coordinate _coordinate;
    private SquareType _type;

    public EmptySquare(Coordinate coordinate)
    {
        _coordinate = coordinate;
        _type = SquareType.Empty;
    }
    
    public bool CheckIfCanPlaceShip()
    {
        return true;
    }
}