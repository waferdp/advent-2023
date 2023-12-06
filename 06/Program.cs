using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input/test_input.txt");
        var program = new Program();
        var part1 = program.Part1(lines);
        Console.WriteLine($"Part1: {part1}");
    }

    public int Part1(string[] lines)
    {
        var races = ParseRaces(lines);
        var times = races.Select(GetChargeTimes);
        return times
            .Select(t => t.high - t.low + 1)
            .Aggregate(1, (a,b) => a * b);
    }

    public static List<(int time, int dist)> ParseRaces(string[] lines)
    {
        var times = ParseValues(lines.First());
        var distances = ParseValues(lines.Last());
        return times.Select((t, i) => (t, distances[i])).ToList();
    }

    private static List<int> ParseValues(string line)
    {
        return Regex
            .Matches(line, "\\d+")
            .Select(m => int.Parse(m.Value)).ToList();
    }

    public (int low, int high) GetChargeTimes((int time, int distance) race)
    {
        var lowest = (race.distance / race.time) + 1;
        var highest = race.distance;
        while(highest >= lowest)
        {
            var dist = (race.time - highest) * (highest);
            if (dist > race.distance) break;
            highest--;
        }
        return (lowest, highest);
    }
}