public class SmartMap
{
    public List<Interval> Maps { get; set; } = new List<Interval>();

    public void Add(long dest, long src, long range)
    {
        var interval = new Interval
        {
            SourceFrom = src,
            SourceTo = src + range,
            DestinationFrom = dest
        };
        Maps.Add(interval);
    }

    public long GetDestination(long source)
    {
        var match = Maps.FirstOrDefault(m => m.IsMatch(source));
        return match != null ? match.Get(source) : source;
    }

}

public class Interval
{
    public long SourceFrom { get; set; }
    public long SourceTo {get; set; }
    public long DestinationFrom{get; set;}

    public bool IsMatch(long num)
    {
        if(SourceFrom <= num && num <= SourceTo)
        {
            return true;
        }
        return false;
    }

    public long Get(long source)
    {
        return source - SourceFrom + DestinationFrom;
    }
}