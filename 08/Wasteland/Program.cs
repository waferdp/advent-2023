namespace Wasteland;

public class Program
{
    public long Part1(string[] lines)
    {
        var path = lines[0].Select(c => (Choice)c);
        var map = new Map(lines.Skip(2).ToArray());
        return map.Navigate(path, "AAA", "ZZZ");
    }

    public long Part2(string[] lines)
    {
        var path = lines[0].Select(c => (Choice)c);
        var map = new Map(lines.Skip(2).ToArray());
        return map.NavigateMultiple(path, "[A]{1}$", "[Z]{1}$");
    }

    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var part1 = new Program().Part1(lines);
        Console.WriteLine($"Part 1: {part1}");

        var part2 = new Program().Part2(lines);
        Console.WriteLine($"Part 2: {part2}");

    }
}