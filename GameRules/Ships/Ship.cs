namespace GameRules.Ships;

public class Ship
{
    private Guid _shipId;
    private List<Coordinate> _coordinates;
    protected int _lifePointsLeft;

    protected Ship()
    {
        _shipId = Guid.NewGuid();
        _coordinates = new List<Coordinate>();
        _lifePointsLeft = 0;
    }

    public Ship(Guid shipId, List<Coordinate> coordinates)
    {
        _shipId = shipId;
        _coordinates = coordinates;
        _lifePointsLeft = 0;
    }

    public List<Coordinate> GetCoordinates()
    {
        return _coordinates;
    }

    public Guid GetId()
    {
        return _shipId;
    }

    public int GetLifePointsLeft()
    {
        return _lifePointsLeft;
    }
}