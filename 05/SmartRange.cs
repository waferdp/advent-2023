public class SmartRange
{
    public long Start { get; set; }
    public long Range { get; set; }

    public SmartRange(long start, long range)
    {
        Start = start;
        Range = range;
    }

    public bool IsMatch(long value)
    {
        if (Start <= value && value < Start + Range)
        {
            return true;
        }
        return false;
    }
}