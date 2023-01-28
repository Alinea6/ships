namespace GameRules.Squares;

public class ShotShipSquare : Square
{
    private Guid _shipId;
    
    public ShotShipSquare(Coordinate coordinate, Guid shipId) : base(coordinate)
    {
        _shipId = shipId;
        _type = SquareType.ShotShip;
    }

    public override Guid? GetShipId()
    {
        return _shipId;
    }
}