public class Draw
{
    public List<DiceSet> Sets { get; set; } = new List<DiceSet>();

    public bool TooFewInBag(DiceSet dice)
    {
        return Sets
        .Where(s => s.Color == dice.Color)
        .Where(s => s.Count > dice.Count)
        .Any();
    }

    public int GetMax(Color color)
    {
        if(!Sets.Any(s => s.Color == color))
        {
            return 0;
        }
        return Sets
            .Where(s => s.Color == color)
            .Select(s => s.Count).Max();
    }

    public List<DiceSet> GetBiggestDraw()
    {
        return new List<DiceSet>()
        {
            new DiceSet
            {
                Color = Color.RED,
                Count = GetMax(Color.RED)
            },
            new DiceSet 
            {
                Color = Color.GREEN,
                Count = GetMax(Color.GREEN)
            },
            new DiceSet 
            {
                Color = Color.BLUE,
                Count = GetMax(Color.BLUE)
            }
        };
    }
}

