
// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public class Program 
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input\\input.txt");
        var games = lines.Select(l => ParseLine(l));
        var bag = new List<DiceSet>()
        {
            new DiceSet
            {
                Color = Color.RED,
                Count = 12
            },
            new DiceSet
            {
                Color = Color.GREEN,
                Count = 13
            },
            new DiceSet
            {
                Color = Color.BLUE,
                Count = 14
            }
        };
        var goodIds = games.Where(g => g.IsPossible(bag));
        
        Console.WriteLine($"Part 1: {goodIds.Sum(g => g.Id)}");
        Console.WriteLine($"Part 2: {games.Sum(g => g.Power)}");
        
    }

    private static Game ParseLine(string line)
    {
        var split = line.Split(":");
        var gameId = int.Parse(Regex.Match(split.First(),"\\d+").Value);

        var draws = split.Last().Split(";");
        var game = new Game
        {
            Id = gameId
        };

        foreach(var draw in draws)
        {
            var diceColors = draw.Split(",");
            var gameDraw = new Draw();

            foreach(var diceColor in diceColors)
            {
                var color = Enum.Parse<Color>(Regex.Match(diceColor, "[a-z]+").Value.ToUpper());
                var amount = int.Parse(Regex.Match(diceColor ,"\\d+").Value);
                
                gameDraw.Sets.Add(new DiceSet
                {
                    Color = color,
                    Count = amount
                });
            }
            game.Draws.Add(gameDraw);
        }
        
        return game;

    }
}
