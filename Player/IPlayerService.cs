
namespace Player;

public interface IPlayerService
{
    ShipCoordinate GetShipCoordinate(int player, string ship);
    void PrintCoordinateInvalidMessage();
}