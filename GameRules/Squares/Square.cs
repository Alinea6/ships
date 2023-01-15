namespace GameRules.Squares;

public class Square
{
    private Coordinate _coordinate;

    public Square()
    {
        _coordinate = new Coordinate('A', '0');
    }
    
    public Square(Coordinate coordinate)
    {
        _coordinate = coordinate;
    }

    public bool CheckIfCanPlaceShip()
    {
        return false;
    }

    public Coordinate GetCoordinate()
    {
        return _coordinate;
    }
}