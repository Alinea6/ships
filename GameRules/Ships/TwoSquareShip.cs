namespace GameRules.Ships;

public class TwoSquareShip : Ship
{

    public TwoSquareShip(Guid shipId, List<Coordinate> coordinates) : base(shipId, coordinates)
    {
        _lifePointsLeft = 2;
    }
}