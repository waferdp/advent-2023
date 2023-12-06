public class Interval
{
    public long SourceFrom { get; set; }
    public long Range {get; set; }
    public long DestinationFrom{get; set;}

    public bool IsMatch(long num)
    {
        if(SourceFrom <= num && num < SourceFrom + Range)
        {
            return true;
        }
        return false;
    }

    public bool ReverseMatch(long value)
    {
        if(DestinationFrom <= value && value < DestinationFrom + Range)
        {
            return true;
        }
        return false;
    }

    public long Get(long source)
    {
        return source - SourceFrom + DestinationFrom;
    }

    public long Reverse(long dest)
    {
        return dest - DestinationFrom + SourceFrom;
    }
}