using ConsoleInterface;
using GameRules;
using GameRules.Ships;
using GameRules.Squares;

namespace Game;

public class Board
{
    private List<Square> _squares;
    private List<Ship> _ships;
    private int _shipCounter;
    private readonly IInterfaceOutputService _interfaceOutputService;

    public Board(IInterfaceOutputService interfaceOutputService)
    {
        _interfaceOutputService = interfaceOutputService;
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
                var coordinate = new Coordinate(letter, i.ToString()[0]);
                _squares.Add(new EmptySquare(coordinate));
            }
        }
    }

    public bool PlaceShip(Ship ship)
    {
        var isShipPlaceable = CheckIfShipIsPlaceable(ship);
        if (isShipPlaceable)
        {
            foreach (var square in ship.GetCoordinates())
            {
                var boardSquare = _squares.First(x =>
                    x.GetCoordinate().GetCoordinates().Item1 == square.GetCoordinates().Item1 &&
                    x.GetCoordinate().GetCoordinates().Item2 == square.GetCoordinates().Item2);
                _squares.Remove(boardSquare);
                var shipSquare = new ShipSquare(square, ship.GetId());
                _squares.Add(shipSquare);
            }
            _ships.Add(ship);
            _shipCounter++;

            return true;
        }

        return false;
    }

    public void OutputBoard()
    {
        _interfaceOutputService.PrintBoard(_squares.Select(x => MapToOutputSquare(x)).ToList());
    }

    private bool CheckIfShipIsPlaceable(Ship ship)
    {
        var placeableCount = ship.GetLifePointsLeft();
        foreach (var square in ship.GetCoordinates())
        {
            var boardSquare = _squares.First(x =>
                x.GetCoordinate().GetCoordinates().Item1 == square.GetCoordinates().Item1 &&
                x.GetCoordinate().GetCoordinates().Item2 == square.GetCoordinates().Item2);
            if (boardSquare.CheckIfCanPlaceShip())
            {
                placeableCount -= 1;
            } ;
        }

        if (placeableCount == 0)
        {
            return true;
        }

        return false;
    }

    private ConsoleInterface.Models.Square MapToOutputSquare(Square square)
    {
        return new ConsoleInterface.Models.Square
        {
            X = square.GetCoordinate().GetCoordinates().Item1,
            Y = square.GetCoordinate().GetCoordinates().Item2,
            Type = (ConsoleInterface.Models.SquareType)Enum.Parse(
                typeof(ConsoleInterface.Models.SquareType),
                square.GetType().ToString())
        };
    }
}