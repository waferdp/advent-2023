public class Game
{
    public int Id { get; set; }
    public List<Draw> Draws {get; set;} = new List<Draw>();
    

    public bool IsPossible(List<DiceSet> dices)
    {
        return dices.All(d => IsPossibleDraw(d));
    }

    public int Power
    {
        get 
        {
            var maxRed = Draws.Select(d => d.GetMax(Color.RED)).Max();
            var maxGreen = Draws.Select(d => d.GetMax(Color.GREEN)).Max();
            var maxBlue = Draws.Select(d => d.GetMax(Color.BLUE)).Max();

            return maxRed * maxGreen * maxBlue;
        }
    }

    private bool IsPossibleDraw(DiceSet dice)
    {
        return !Draws.Any(d => d.TooFewInBag(dice));
    }
}
