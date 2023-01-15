
namespace Player;

public class PlayerService : IPlayerService
{
    public ShipCoordinate GetShipCoordinate(int player, string ship)
    {
        Console.WriteLine($"Player {player} please place {ship} ship on the board");
        Console.WriteLine("Please insert start position(letter then number");
        var startPosition = Console.ReadLine();
        var finishPosition = "";
        if (ship != "OneSquare")
        {
            Console.WriteLine("Please insert finish position (letter then number");
            finishPosition = Console.ReadLine();
        }

        return new ShipCoordinate
        {
            StartingPosition = startPosition,
            FinishPosition = finishPosition
        };
    }

    public void PrintCoordinateInvalidMessage()
    {
        Console.WriteLine("Invalid coordinates, please try specifying coordinates again");
    }
}