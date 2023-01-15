using ConsoleInterface;
using Game;
using Player;

IInterfaceOutputService consoleService = new ConsoleOutputService();
IPlayerService playerService = new PlayerService();

var game = new Battle(consoleService, playerService);
game.PlaceShips();
//game.Run();
//game.Finish();
    
