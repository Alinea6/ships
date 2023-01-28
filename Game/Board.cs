using ConsoleInterface;
using GameRules;
using GameRules.Ships;
using GameRules.Squares;
using Player;
using Player.Models;

namespace Game;

public class Board
{
    private List<Square> _squares;
    private List<Ship> _ships;
    private int _shipCounter;
    private readonly IInterfaceOutputService _interfaceOutputService;
    private readonly IPlayerService _playerService;

    public Board(IInterfaceOutputService interfaceOutputService, IPlayerService playerService)
    {
        _interfaceOutputService = interfaceOutputService;
        _playerService = playerService;
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
        _interfaceOutputService.PrintPlayerBoard(_squares.Select(x => BoardMapper.MapToOutputSquare(x)).ToList());
    }

    public List<OpponentSquare> GetOpponentBoard()
    {
        return _squares.Select(x => BoardMapper.MapToOpponentSquare(x)).ToList();
    }

    public bool Shoot(Coordinate coordinate)
    {
        var isSquareShootable = CheckIfSquareIsShootable(coordinate);
        if (isSquareShootable)
        {
            var shotSquare = _squares.First(x => 
                x.GetCoordinate().GetCoordinates().Item1 == coordinate.GetCoordinates().Item1
                && x.GetCoordinate().GetCoordinates().Item2 == coordinate.GetCoordinates().Item2);
            if (shotSquare.GetType() == SquareType.Empty)
            {
                _playerService.PrintShotMissedMessage();
                _squares.Remove(shotSquare);
                var shotEmptySquare = new ShotEmptySquare(coordinate);
                _squares.Add(shotEmptySquare);
                return false;
            }
            else
            {
                _playerService.PrintShipHitMessage();
                var shipId = shotSquare.GetShipId();
                _squares.Remove(shotSquare);
                var shotShipSquare = new ShotShipSquare(coordinate, (Guid)shipId);
                _squares.Add(shotShipSquare);
                var ship = _ships.First(x => x.GetId() == shipId);
                var shipHealth = ship.Shoot();
                if (shipHealth == 0)
                {
                    _ships.Remove(ship);
                    _shipCounter -= 1;
                    _playerService.PrintShipSunkMessage();
                }
                return true;
            }
        }

        throw new Exception("Invalid coordinates. This square was already hit.");
    }

    public bool CheckIfAllShipsSunk()
    {
        return _shipCounter == 0;
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

    private bool CheckIfSquareIsShootable(Coordinate coordinate)
    {
        var boardSquare = _squares.First(x =>
            x.GetCoordinate().GetCoordinates().Item1 == coordinate.GetCoordinates().Item1 &&
            x.GetCoordinate().GetCoordinates().Item2 == coordinate.GetCoordinates().Item2);
        return boardSquare.CheckIfCanShoot();
    }
}