namespace Camel;

public class Program
{
    public static long Part1(string[] lines)
    {
        var hands = lines.Select(line => new Hand(line)).ToList();
        hands.Sort();

        return hands.Select((h, i) => h.BidValue * (i+1)).Sum();
    }

    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var part1 = Part1(lines);
        Console.WriteLine($"Part 1: {part1}");
    }
}
