namespace Pipe;
public class PipeGraph: Graph
{
    private readonly Matrix2d<string> matrix;

    public (int x, int y) Animal {get ; private set;}
    private readonly List<(int x, int y)> directions = new (){(0, -1), (1, 0), (0, 1), (-1, 0)};

    public PipeGraph(string[] lines)
    {
        var listOfLists = lines.Select(line => line.Select(c => c.ToString()).ToList()).ToList();
        matrix = new Matrix2d<string>(listOfLists, ".");

        Animal = matrix.Find("S") ?? (-1, -1);
    }

    public List<Move> GetAllowedMoves((int x, int y) source)
    {
        return directions
            .Select(d => new Move(source ,(d.x + source.x, d.y + source.y)))
            .Where(IsAllowedMove)
            .ToList();
    }

    public bool IsAllowedMove(Move move)
    {
        //if(move.Distance != 1) return false;
        var srcValue = matrix.Get(move.Source);
        var destValue = matrix.Get(move.Destination);
        
        var moveType = move.Type;
        
        switch(moveType)
        {
            case MoveType.NORTH: return AllowedNS(srcValue, destValue);
            case MoveType.EAST: return AllowedWE(srcValue, destValue);
            case MoveType.SOUTH: return AllowedNS(destValue, srcValue);
            case MoveType.WEST: return AllowedWE(destValue, srcValue);
            default: throw new Exception($"Unknown move type: {moveType}");
        }
    }

    private bool AllowedNS(string southValue, string northValue)
    {
        return AllowedMoves.NorthAllowed
            .Any(n => n == southValue)
            &&
            AllowedMoves.SouthAllowed
            .Any(s => s == northValue);
    }

    private bool AllowedWE(string westValue, string eastValue)
    {
        return AllowedMoves.WestAllowed
            .Any(n => n == eastValue)
            &&
            AllowedMoves.EastAllowed
            .Any(s => s == westValue);
    }


}