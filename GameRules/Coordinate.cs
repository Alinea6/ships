namespace GameRules;

public class Coordinate
{
    private readonly char _x;
    private readonly char _y;

    public Coordinate(char x, char y)
    {
        _x = Char.ToUpper(x);
        _y = y;
        if (!Validate())
        {
            throw new Exception("Invalid Coordinate");
        };
    }

    private bool Validate()
    {
        if (_x >= 'A' && _x <= 'J')
        {
            if (_y >= '0' && _y <= '9')
            {
                return true;
            }
        }
        return false;
    }

    public Tuple<char, char> GetCoordinates()
    {
        return new Tuple<char, char>(_x, _y);
    }
}