using GameRules.Squares;

namespace Game;

public class Board
{
    private List<Square> _squares;
    private List<Ship> _ships;
    private int _shipCounter;

    public Board()
    {
        _squares = new List<Square>();
        _ships = new List<Ship>();
        _shipCounter = 0;
        CreateEmptyBoard();
    }

    private void CreateEmptyBoard()
    {
        var letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        foreach (var letter in letters)
        {
            for (int i = 0; i < 10; i++)
            {
                var coordinate = new Coordinate(letter, (char)i);
                var square = new EmptySquare(coordinate);
                _squares.Add(square);
            }
        }
    }

    public void PrintBoard()
    {
        throw new NotImplementedException();
    }
}