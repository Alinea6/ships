namespace GameRules.Ships;

public class TwoSquareShip : Ship
{
    private Guid _shipId;
    private List<Coordinate> _coordinates;
    private int _lifePointsLeft;

    public TwoSquareShip(Guid shipId, List<Coordinate> coordinates)
    {
        _shipId = shipId;
        _coordinates = coordinates;
        _lifePointsLeft = 2;
    }
}