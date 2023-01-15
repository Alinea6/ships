namespace GameRules.Squares;

public class ShipSquare : Square
{
    private Coordinate _coordinate;
    private int _shipId;

    public ShipSquare(Coordinate coordinate, int shipId)
    {
        _coordinate = coordinate;
        _shipId = shipId;
    }
    
    
}