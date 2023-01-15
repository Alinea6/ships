namespace GameRules.Ships;

public class ShipBuilder
{
    private Coordinate? _startPosition;
    private Coordinate? _finishPosition;
    private ShipType _type;
    
    public ShipBuilder(string startPosition, string finishPosition, ShipType type)
    {
        var coordinates = ConvertToCoordinates(startPosition, finishPosition);
        _startPosition = coordinates.Item1;
        _finishPosition = coordinates.Item2;
        _type = type;
    }

    private Tuple<Coordinate?, Coordinate?> ConvertToCoordinates(string startPosition, string finishPosition)
    {
        if (startPosition.Length == 2 && 
            (finishPosition.Length == 0 || finishPosition.Length == 2))
        {
            try
            {
                var start = new Coordinate(startPosition[0], startPosition[1]);
                if (finishPosition.Length == 2)
                {
                    var finish = new Coordinate(finishPosition[0], finishPosition[1]);
                    return new Tuple<Coordinate?, Coordinate?>(start, finish);
                }
                return new Tuple<Coordinate?, Coordinate?>(start, null);
            }
            catch (Exception e)
            {
                throw new Exception("Invalid coordinates");
            }
        }
        throw new Exception("Invalid coordinates");
    }

    public ShipBuilt Build()
    {
        if (AreCoordinatesValid())
        {
            
        }
        throw new Exception("Invalid coordinates");
    }

    private bool AreCoordinatesValid()
    {
        if (_type == ShipType.OneSquare)
        {
            if (_finishPosition == null)
            {
                return true;
            }

            return false;
        }

        var startCoordinates = _startPosition.GetCoordinates();
        var finishCoordinates = _finishPosition.GetCoordinates();
        if (_type == ShipType.TwoSquare)
        {
            if (startCoordinates.Item1 == finishCoordinates.Item1 - 1 &&
                 startCoordinates.Item2 == finishCoordinates.Item2)
            {
                return true;
            }

            if (startCoordinates.Item2 == finishCoordinates.Item2 - 1 &&
                startCoordinates.Item1 == finishCoordinates.Item1)
            {
                return true;
            }
            
            return false;
        }

        if (_type == ShipType.ThreeSquare)
        {
            if (startCoordinates.Item1 == finishCoordinates.Item1 - 2 &&
                startCoordinates.Item2 == finishCoordinates.Item2)
            {
                return true;
            }

            if (startCoordinates.Item2 == finishCoordinates.Item2 - 2 &&
                startCoordinates.Item1 == finishCoordinates.Item1)
            {
                return true;
            }
            
            return false;
        }

        if (_type == ShipType.FourSquare)
        {
            if (startCoordinates.Item1 == finishCoordinates.Item1 - 3 &&
                startCoordinates.Item2 == finishCoordinates.Item2)
            {
                return true;
            }

            if (startCoordinates.Item2 == finishCoordinates.Item2 - 3 &&
                startCoordinates.Item1 == finishCoordinates.Item1)
            {
                return true;
            }
            
            return false;
        }
        
        return false;
    }
}