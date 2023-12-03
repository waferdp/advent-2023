using System.Text.RegularExpressions;

public class Program
{
    public List<Position> Symbols;
    public List<Position> Gears;
    public List<Part> Parts;

    public Program(string[] lines)
    {
        Symbols = lines.SelectMany(ParseSymbols).ToList();
        Parts = lines.SelectMany(ParseParts).ToList();
        Gears = lines.SelectMany(ParseGears).ToList();

        Console.WriteLine($"Parts: {Parts.Count()}, Symbols: {Symbols.Count()}");
        var notAdjacent = Parts.Where(p => !Symbols.Any(s => p.IsAdjacent(s))).ToList();
        var adjacent = Parts.Where(p => Symbols.Any(s => p.IsAdjacent(s))).ToList();

        var sum = adjacent.Select(s => s.Partnumber).Sum();

        var gearRatio = Gears.Select(g => GearRatio(g)).Sum();
        Console.WriteLine($"Part 1: {sum}, Part 2: {gearRatio}");

    }

    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input\\input.txt");
        //var lines = File.ReadAllLines("input\\test_input.txt");
        var program = new Program(lines);
        
    }

    private List<Part> ParseParts(string line, int y)
    {
        var matches = Regex.Matches(line, "\\d+");
        return matches.Select(m => new Part
        {
            Start = new Position(m.Index, y),
            End = new Position(m.Index + m.Length - 1, y),
            Partnumber = int.Parse(m.Value)
        })
        .ToList();
    }

    private List<Position> ParseSymbols(string line, int y)
    {
        var matches = Regex.Matches(line, "[^.|\\w]");
        return matches.Select(m => new Position(m.Index, y)).ToList();
    }

    private List<Position> ParseGears(string line, int y)
    {
        var matches= Regex.Matches(line, "[*]");
        return matches.Select(m => new Position(m.Index, y)).ToList();
    }

    private int GearRatio(Position pos)
    {
        var closeParts = Parts
            .Where(p => Math.Abs(p.Start.Y - pos.Y) <= 1)
            .Where(p => p.IsAdjacent(pos));
        
        if(closeParts.Count() == 2)
        {
            return closeParts
            .Select(p => p.Partnumber)
            .Aggregate(1, (a,b) => a * b);
        }
        return 0;
    }
}
