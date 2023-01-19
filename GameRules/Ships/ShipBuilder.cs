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
            var coordinates = ConvertToListOfCoordinates();
            switch (_type)
            {
                case ShipType.OneSquare:
                    var oneSquare = new OneSquareShip(Guid.NewGuid(), coordinates);
                    return new ShipBuilt
                    {
                        Squares = coordinates,
                        Ship = oneSquare
                    };
                case ShipType.TwoSquare:
                    var twoSquare = new TwoSquareShip(Guid.NewGuid(), coordinates);
                    return new ShipBuilt
                    {
                        Squares = coordinates,
                        Ship = twoSquare
                    };
                case ShipType.ThreeSquare:
                    var threeSquare = new ThreeSquareShip(Guid.NewGuid(), coordinates);
                    return new ShipBuilt
                    {
                        Squares = coordinates,
                        Ship = threeSquare
                    };
                case ShipType.FourSquare:
                    var fourSquare = new FourSquareShip(Guid.NewGuid(), coordinates);
                    return new ShipBuilt
                    {
                        Squares = coordinates,
                        Ship = fourSquare
                    };
            }
        }
        throw new Exception("Invalid coordinates");
    }

    private bool AreCoordinatesValid()
    {
        if (_type == ShipType.OneSquare)
        {
            return AreCoordinatesValidForOneSquare();
        }

        if (_type == ShipType.TwoSquare)
        {
            return AreCoordinatesValidForTwoSquare();
        }

        if (_type == ShipType.ThreeSquare)
        {
            return AreCoordinatesValidForThreeSquare();
        }

        if (_type == ShipType.FourSquare)
        {
            return AreCoordinatesValidForFourSquare();
        }
        
        return false;
    }

    private bool AreCoordinatesValidForOneSquare()
    {
        if (_finishPosition == null)
        {
            return true;
        }

        return false;
    }

    private bool AreCoordinatesValidForTwoSquare()
    {
        var startCoordinates = _startPosition.GetCoordinates();
        var finishCoordinates = _finishPosition.GetCoordinates();
        
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

    private bool AreCoordinatesValidForThreeSquare()
    {
        var startCoordinates = _startPosition.GetCoordinates();
        var finishCoordinates = _finishPosition.GetCoordinates();
        
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

    private bool AreCoordinatesValidForFourSquare()
    {
        var startCoordinates = _startPosition.GetCoordinates();
        var finishCoordinates = _finishPosition.GetCoordinates();
        
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

    private List<Coordinate> ConvertToListOfCoordinates()
    {
        if (_type == ShipType.OneSquare)
        {
            return new List<Coordinate> { _startPosition };
        }

        if (_type == ShipType.TwoSquare)
        {
            return new List<Coordinate> { _startPosition, _finishPosition };
        }

        if (_type == ShipType.ThreeSquare)
        {
            var startCoordinates = _startPosition.GetCoordinates();
            var finishCoordinates = _finishPosition.GetCoordinates();
            if (startCoordinates.Item1 == finishCoordinates.Item1 - 2 &&
                startCoordinates.Item2 == finishCoordinates.Item2)
            {
                return new List<Coordinate>
                {
                    _startPosition,
                    new (Convert.ToChar(startCoordinates.Item1 + 1), startCoordinates.Item2),
                    _finishPosition
                };
            }
            return new List<Coordinate>
            {
                _startPosition,
                new (startCoordinates.Item1, Convert.ToChar(startCoordinates.Item2 + 1)),
                _finishPosition
            };
        }
        else
        {
            var startCoordinates = _startPosition.GetCoordinates();
            var finishCoordinates = _finishPosition.GetCoordinates();
            if (startCoordinates.Item1 == finishCoordinates.Item1 - 3 &&
                startCoordinates.Item2 == finishCoordinates.Item2)
            {
                return new List<Coordinate>
                {
                    _startPosition,
                    new (Convert.ToChar(startCoordinates.Item1 + 1), startCoordinates.Item2),
                    new (Convert.ToChar(startCoordinates.Item1 + 2), startCoordinates.Item2),
                    _finishPosition
                };
            }
            return new List<Coordinate>
            {
                _startPosition,
                new (startCoordinates.Item1, Convert.ToChar(startCoordinates.Item2 + 1)),
                new (startCoordinates.Item1, Convert.ToChar(startCoordinates.Item2 + 2)),
                _finishPosition
            };
        }
    }
}