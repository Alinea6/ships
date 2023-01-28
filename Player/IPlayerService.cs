
using Player.Models;

namespace Player;

public interface IPlayerService
{
    ShipCoordinate GetShipCoordinate(int player, string ship);
    void PrintCoordinateInvalidMessage();
    string GetShootCoordinate(int player, List<OpponentSquare> board);
    void PrintShipHitMessage();
    void PrintShipSunkMessage();
    void PrintShotMissedMessage();
}