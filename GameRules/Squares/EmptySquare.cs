namespace GameRules.Squares;

public class EmptySquare : Square
{

    public EmptySquare(Coordinate coordinate) : base(coordinate)
    {
        _type = SquareType.Empty;
    }

    public override bool CheckIfCanPlaceShip()
    {
        return true;
    }
}