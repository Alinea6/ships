using ConsoleInterface;
using Game;
using Player;

IInterfaceOutputService consoleService = new ConsoleOutputService();
IPlayerService playerService = new PlayerService();
var game = new Battle(consoleService, playerService);
game.PlaceShips(0);
game.PlaceShips(1);
var player = game.Run();
game.Finish(player);
    
