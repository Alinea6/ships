
using Player.Models;

namespace Player;

public class PlayerService : IPlayerService
{
    private readonly Dictionary<string, string> _explanations = new()
    {
        { "O", "Empty field" },
        { "X", "Missed shot" },
        { "D", "Ship that has been shot" }
    };
    private readonly List<char> _fields = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J'};
    
    public ShipCoordinate GetShipCoordinate(int player, string ship)
    {
        Console.WriteLine($"Player {player} please place {ship} ship on the board");
        Console.WriteLine("Please insert start position(letter then number)");
        var startPosition = Console.ReadLine();
        var finishPosition = "";
        if (ship != "OneSquare")
        {
            Console.WriteLine("Please insert finish position (letter then number)");
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

    public string GetShootCoordinate(int player, List<OpponentSquare> board)
    {
        PrintOpponentBoard(board);
        Console.WriteLine($"Player {player} please specify coordinates for the next shot (letter then number)");
        var coordinate = Console.ReadLine();
        return coordinate;
    }

    public void PrintShipHitMessage()
    {
        Console.WriteLine("Your shot was accurate! You managed to hit one of the opponent's ships. You can shoot again.");
    }

    public void PrintShipSunkMessage()
    {
        Console.WriteLine("You managed to sunk one of the opponent's ships. You're closer to victory now.");
    }

    public void PrintShotMissedMessage()
    {
        Console.WriteLine("Unfortunately, this time you missed your shot. This is the end of your turn");
    }

    private void PrintOpponentBoard(List<OpponentSquare> board)
    {
        Console.WriteLine(PrepareExplanationMessage());
        Console.WriteLine(PrepareFirstLine());
        Console.WriteLine(PrepareBoard(board));
    }
    
    private string PrepareExplanationMessage()
    {
        var result = "This is your opponent board" + "\n";
        foreach (var key in _explanations.Keys)
        {
            result += key + ": " + _explanations[key] + "\n";
        }
        return result;
    }

    private string PrepareFirstLine()
    {
        var result = "   ";
        foreach (var character in _fields)
        {
            result += character + " ";
        }
        return result;
    }

    private string PrepareBoard(List<OpponentSquare> board)
    {
        var result = "";
        for (var i = 0; i < 10; i++)
        {
            result += i.ToString() + "  ";
            foreach (var character in _fields)
            {
                var square = board.First(x => x.X == character && x.Y == i.ToString()[0]);
                if (square.Type == OpponentSquareType.Empty)
                {
                    result += "O ";
                }
                else if (square.Type == OpponentSquareType.ShotEmpty)
                {
                    result += "X ";
                }
                else if (square.Type == OpponentSquareType.ShotShip)
                {
                    result += "D ";
                }
            }

            result += "\n";
        }

        return result;
    }
}