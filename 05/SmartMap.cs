public class SmartMap
{
    public List<Interval> Maps { get; set; } = new List<Interval>();

    public void Add(long dest, long src, long range)
    {
        var interval = new Interval
        {
            SourceFrom = src,
            Range = range,
            DestinationFrom = dest
        };
        Maps.Add(interval);
    }

    public long GetDestination(long source)
    {
        var match = Maps.FirstOrDefault(m => m.IsMatch(source));
        return match != null ? match.Get(source) : source;
    }

    public long GetSource(long destination)
    {
        var match = Maps.FirstOrDefault(m => m.ReverseMatch(destination));
        return match != null ? match.Reverse(destination) : destination;
    }

}
