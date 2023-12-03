public class Part
{
    public Position Start { get; set; }
    public Position End { get; set; }

    public int Partnumber { get; set; }
    public bool IsAdjacent(Position pos)
    {
        return Start.Distance(pos) <= 1 || End.Distance(pos) <= 1;
    }
}
