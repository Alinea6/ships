namespace GameRules.Ships;

public class OneSquareShip : Ship
{
    private Guid _shipId;
    private List<Coordinate> _coordinates;
    private int _lifePointsLeft;

    public OneSquareShip(Guid shipId, List<Coordinate> coordinates)
    {
        _shipId = shipId;
        _coordinates = coordinates;
        _lifePointsLeft = 1;
    }
}