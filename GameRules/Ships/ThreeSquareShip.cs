namespace GameRules.Ships;

public class ThreeSquareShip : Ship
{
    private Guid _shipId;
    private List<Coordinate> _coordinates;
    private int _lifePointsLeft;

    public ThreeSquareShip(Guid shipId, List<Coordinate> coordinates)
    {
        _shipId = shipId;
        _coordinates = coordinates;
        _lifePointsLeft = 3;
    }
}