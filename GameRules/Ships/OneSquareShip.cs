namespace GameRules.Ships;

public class OneSquareShip : Ship
{

    public OneSquareShip(Guid shipId, List<Coordinate> coordinates) : base(shipId, coordinates)
    {
        _lifePointsLeft = 1;
    }
}