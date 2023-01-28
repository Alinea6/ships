
using ConsoleInterface.Models;

namespace ConsoleInterface;

public interface IInterfaceOutputService
{
    void PrintWelcomeMessage();
    void PrintPlayerBoard(List<Square> board);
    void PrintFinishGameMessage(int player);
}