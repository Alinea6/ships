namespace GameRules.Squares;

public class ShipSquare : Square
{
    private Guid _shipId;

    public ShipSquare(Coordinate coordinate, Guid shipId) : base(coordinate)
    {
        _shipId = shipId;
        _type = SquareType.Ship;
    }
    
    public override bool CheckIfCanShoot()
    {
        return true;
    }
    
    public override Guid? GetShipId()
    {
        return _shipId;
    }
}