using ConsoleInterface;
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
        var player0 = new Board();
        var player1 = new Board();
        _boards = new List<Board> { player0, player1 };
        _currentPlayer = 0;
        _shipsToPlace = new List<ShipType>();
        _interfaceOutputService.PrintWelcomeMessage();
    }

    public void PlaceShips()
    {
        FillShipList();
        while (_shipsToPlace.Any())
        {
            _boards[_currentPlayer].PrintBoard();
            var coordinate = _playerService.GetShipCoordinate(_currentPlayer, _shipsToPlace.First().ToString());

            try
            {
                var builder= new ShipBuilder(
                    coordinate.StartingPosition, 
                    coordinate.FinishPosition, 
                    _shipsToPlace.First());
                var ship = builder.Build();
                if (_boards[_currentPlayer].PlaceShip(ship.Ship))
                {
                    _shipsToPlace.RemoveAt(0);
                }
            }
            catch (Exception e)
            {
                _playerService.PrintCoordinateInvalidMessage();
            }
        }
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
}