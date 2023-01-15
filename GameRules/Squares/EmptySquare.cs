namespace GameRules.Squares;

public class EmptySquare : Square
{
    private Coordinate _coordinate;

    public EmptySquare(Coordinate coordinate)
    {
        _coordinate = coordinate;
    }
    
    public bool CheckIfCanPlaceShip()
    {
        return true;
    }
}