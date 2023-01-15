
namespace ConsoleInterface;

public class ConsoleOutputService : IInterfaceOutputService
{
    public void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome!");
    }
}