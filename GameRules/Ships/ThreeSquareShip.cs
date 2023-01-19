namespace GameRules.Ships;

public class ThreeSquareShip : Ship
{

    public ThreeSquareShip(Guid shipId, List<Coordinate> coordinates) : base(shipId, coordinates)
    {
        _lifePointsLeft = 3;
    }
}