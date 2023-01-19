namespace GameRules.Squares;

public class Square
{
    private Coordinate _coordinate;
    protected SquareType _type;

    public Square()
    {
    }
    
    public Square(Coordinate coordinate)
    {
        _coordinate = coordinate;
    }

    public virtual bool CheckIfCanPlaceShip()
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