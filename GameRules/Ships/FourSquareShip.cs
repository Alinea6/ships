namespace GameRules.Ships;

public class FourSquareShip : Ship
{

    public FourSquareShip(Guid shipId, List<Coordinate> coordinates) : base(shipId, coordinates)
    {
        _lifePointsLeft = 4;
    }
}