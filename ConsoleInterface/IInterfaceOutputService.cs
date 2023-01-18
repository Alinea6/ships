
using ConsoleInterface.Models;

namespace ConsoleInterface;

public interface IInterfaceOutputService
{
    void PrintWelcomeMessage();
    void PrintBoard(List<Square> board);
}