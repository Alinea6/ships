namespace GameRules.Squares;

public class Square
{
    private Coordinate _coordinate;
    private SquareType _type;

    public Square()
    {
        _coordinate = new Coordinate('A', '0');
        _type = SquareType.Empty;
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

    public SquareType GetType()
    {
        return _type;
    }
}