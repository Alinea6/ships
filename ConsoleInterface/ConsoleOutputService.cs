
using ConsoleInterface.Models;

namespace ConsoleInterface;

public class ConsoleOutputService : IInterfaceOutputService
{
    private readonly Dictionary<string, string> _explanations = new Dictionary<string, string>
    {
        { "O", "Empty field" },
        { "X", "Missed shot" },
        { "S", "Ship that hasn't been shot" },
        { "D", "Ship that has been shot" }
    };
    private readonly List<char> _fields = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J'};

    public void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome!");
    }

    public void PrintPlayerBoard(List<Square> board)
    {
        Console.WriteLine(PrepareExplanationMessage());
        Console.WriteLine(PrepareFirstLine());
        Console.WriteLine(PrepareBoard(board));
    }

    public void PrintFinishGameMessage(int player)
    {
        Console.WriteLine($"Congratulations! Player {player} won the game!");
    }

    private string PrepareExplanationMessage()
    {
        var result = "This is your board" + "\n";
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

    private string PrepareBoard(List<Square> board)
    {
        var result = "";
        for (var i = 0; i < 10; i++)
        {
            result += i.ToString() + "  ";
            foreach (var character in _fields)
            {
                var square = board.First(x => x.X == character && x.Y == i.ToString()[0]);
                if (square.Type == SquareType.Empty)
                {
                    result += "O ";
                }
                else if (square.Type == SquareType.Ship)
                {
                    result += "S ";
                }
                else if (square.Type == SquareType.ShotEmpty)
                {
                    result += "X ";
                }
                else if (square.Type == SquareType.ShotShip)
                {
                    result += "D ";
                }
            }

            result += "\n";
        }

        return result;
    }
}