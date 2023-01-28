using ConsoleInterface;
using GameRules;
using GameRules.Ships;
using Player;

namespace Game;

public class Battle
{
    private List<Board> _boards;
    private int _currentPlayer;
    private List<ShipType> _shipsToPlace;
    private readonly IInterfaceOutputService _interfaceOutputService;
    private readonly IPlayerService _playerService;

    public Battle(IInterfaceOutputService interfaceOutputService, IPlayerService playerService)
    {
        _interfaceOutputService = interfaceOutputService;
        _playerService = playerService;
        var player0 = new Board(interfaceOutputService, playerService);
        var player1 = new Board(interfaceOutputService, playerService);
        _boards = new List<Board> { player0, player1 };
        _currentPlayer = 0;
        _shipsToPlace = new List<ShipType>();
        _interfaceOutputService.PrintWelcomeMessage();
    }

    public void PlaceShips(int player)
    {
        _currentPlayer = player;
        FillShipList();
        while (_shipsToPlace.Any())
        {
            _boards[_currentPlayer].OutputBoard();
            var coordinate = _playerService.GetShipCoordinate(_currentPlayer, _shipsToPlace.First().ToString());

            try
            {
                var builder = new ShipBuilder(
                    coordinate.StartingPosition, 
                    coordinate.FinishPosition, 
                    _shipsToPlace.First());
                var ship = builder.Build();
                if (_boards[_currentPlayer].PlaceShip(ship.Ship))
                {
                    _shipsToPlace.RemoveAt(0);
                }
                else
                {
                    _playerService.PrintCoordinateInvalidMessage();
                }
            }
            catch (Exception e)
            {
                _playerService.PrintCoordinateInvalidMessage();
            }
        }
    }

    public int Run()
    {
        _currentPlayer = 0;
        var gameStillPlaying = true;
        while (gameStillPlaying)
        {
            gameStillPlaying = PlayPlayerTurn();
            if (gameStillPlaying == false)
            {
                break;
            }
            if (_currentPlayer == 0)
            {
                _currentPlayer = 1;
            }
            else
            {
                _currentPlayer = 0;
            }
        }

        return _currentPlayer;
    }

    public void Finish(int player)
    {
        _interfaceOutputService.PrintFinishGameMessage(player);
    }

    private void FillShipList()
    {
        _shipsToPlace = new List<ShipType>
        {
            ShipType.OneSquare, ShipType.OneSquare, ShipType.OneSquare, ShipType.OneSquare,
            ShipType.TwoSquare, ShipType.TwoSquare, ShipType.TwoSquare,
            ShipType.ThreeSquare, ShipType.ThreeSquare, ShipType.FourSquare
        };
    }

    private bool PlayPlayerTurn()
    {
        var playerStillShooting = true;
        var opponent = _currentPlayer == 0 ? 1 : 0;
        _boards[_currentPlayer].OutputBoard();
        while (playerStillShooting)
        {
            var accurateShot = Shoot();
            if (accurateShot)
            {
                var allShipsSunk = _boards[opponent].CheckIfAllShipsSunk();
                if (allShipsSunk)
                {
                    return false;
                }
            }
            else
            {
                playerStillShooting = false;
            }
        }

        return true;
    }

    private bool Shoot()
    {
        while (true)
        {
            var opponent = _currentPlayer == 0 ? 1 : 0;
            var opponentBoard = _boards[opponent].GetOpponentBoard();
            var coordinate = _playerService.GetShootCoordinate(_currentPlayer, opponentBoard);
            if (coordinate.Length == 2)
            {
                try
                {
                    var shootCoordinate = new Coordinate(coordinate[0], coordinate[1]);
                    var shotAccurate = _boards[opponent].Shoot(shootCoordinate);
                    return shotAccurate;
                }
                catch (Exception e)
                {
                    _playerService.PrintCoordinateInvalidMessage();
                }
            }
            else
            {
                _playerService.PrintCoordinateInvalidMessage();
            }
        }
        return false;
    }
}