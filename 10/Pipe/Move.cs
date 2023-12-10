namespace Pipe;

public class Move
{
    public (int x, int y) Source {get; private set;}
    public (int x, int y) Destination {get; private set;}
    
    public Move((int,int) source, (int, int) destination)
    {
        Source = source;
        Destination = destination;
    }

    public int Distance
    {
        get 
        {
            return Math.Abs(Destination.x - Source.x) + Math.Abs(Destination.y - Source.x);
        }
    }

    public MoveType Type
    {
        get 
        {
            //if(Distance != 1) throw new Exception("Invalid move");
            if(Destination.y - Source.y < 0) return MoveType.NORTH;
            if(Destination.x - Source.x > 0) return MoveType.EAST;
            if(Destination.y - Source.y > 0) return MoveType.SOUTH;
            return MoveType.WEST;
        }
    }
    
}
