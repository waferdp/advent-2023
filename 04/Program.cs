using System.Text.RegularExpressions;

public class Program
{
    public Program(string[] lines)
    {
        var matches = lines.Select(l => GetLineValue(l)).ToList();
        Console.WriteLine($"Part 1: {matches.Sum()}");

        var totalCards = GetTotalCards(lines.Select(l => GetMatches(l)).ToList());
        Console.WriteLine($"Part 2: {totalCards.Sum()}");
    }

    private List<int> GetTotalCards(List<int> matches)
    {
        var cardsMatches = new List<(int, int)>();
        cardsMatches = matches.Select(m => (1, m)).ToList();
        //cardsMatches[0] = (1, cardsMatches[0].Item2);

        for (var i = 0; i < cardsMatches.Count(); i++)
        {
            var (card, wins) = cardsMatches[i];
            var increase = Math.Min(wins - 1, cardsMatches.Count() - 1 - i);

            for (var j = 1; j <= wins; j++)
            {
                var index = j + i;
                if(index >= cardsMatches.Count()) continue;
                var (c,m) = cardsMatches[index];
                cardsMatches[index] = (c+card, m);
            }
        }
        return cardsMatches.Select(cm => cm.Item1).ToList();
    }

    private int GetLineValue(string line)
    {
        var matches = GetMatches(line);
        return matches > 0 ? (int)Math.Pow(2, matches - 1) : 0;

    }

    private int GetMatches(string line)
    {
        var winning = ParseWinning(line);
        var numbers = ParseNumbers(line);

        return numbers.Where(n => winning.Any(w => n == w)).Count();
    }    

    public static void Main(string[] args)
    {
        //var lines = File.ReadAllLines("input/test_input.txt");
        var lines = File.ReadAllLines("input/input.txt");
        var program = new Program(lines);
    }

    private List<int> ParseWinning(string line)
    {
        return Parse(line, 0);
    }

    private List<int> ParseNumbers(string line)
    {
        return Parse(line, 1);
    }

    private List<int> Parse(string line, int index)
    {
        var numbers = line.Split(":").Last().Split("|")[index];
        return Regex.Matches(numbers, "\\d+").Select(v => int.Parse(v.Value)).ToList();
    }
} 