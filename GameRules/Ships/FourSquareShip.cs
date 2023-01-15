namespace GameRules.Ships;

public class FourSquareShip : Ship
{
    private Guid _shipId;
    private List<Coordinate> _coordinates;
    private int _lifePointsLeft;

    public FourSquareShip(Guid shipId, List<Coordinate> coordinates)
    {
        _shipId = shipId;
        _coordinates = coordinates;
        _lifePointsLeft = 4;
    }
}