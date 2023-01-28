using GameRules.Squares;
using Player.Models;

namespace Game;

public class BoardMapper
{
    public static ConsoleInterface.Models.Square MapToOutputSquare(Square square)
    {
        return new ConsoleInterface.Models.Square
        {
            X = square.GetCoordinate().GetCoordinates().Item1,
            Y = square.GetCoordinate().GetCoordinates().Item2,
            Type = (ConsoleInterface.Models.SquareType)Enum.Parse(
                typeof(ConsoleInterface.Models.SquareType),
                square.GetType().ToString())
        };
    }

    public static OpponentSquare MapToOpponentSquare(Square square)
    {
        return new OpponentSquare
        {
            X = square.GetCoordinate().GetCoordinates().Item1,
            Y = square.GetCoordinate().GetCoordinates().Item2,
            Type = square.GetType() != SquareType.Ship 
                ? (OpponentSquareType)Enum.Parse(typeof(OpponentSquareType),
                square.GetType().ToString())
                : (OpponentSquareType)Enum.Parse(typeof(OpponentSquareType),
                    SquareType.Empty.ToString())
        };
    }
}