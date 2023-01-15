namespace GameRules.Squares;

public class ShipSquare : Square
{
    private Coordinate _coordinate;
    private Guid _shipId;

    public ShipSquare(Coordinate coordinate, Guid shipId)
    {
        _coordinate = coordinate;
        _shipId = shipId;
    }
}