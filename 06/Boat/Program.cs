using System.Text.RegularExpressions;
namespace Boat;
public class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var program = new Program();
        var part1 = program.Part1(lines);
        Console.WriteLine($"Part1: {part1}");
        var part2 = program.Part2(lines);
        Console.WriteLine($"Part2: {part2}");
    }

    public long Part1(string[] lines)
    {
        var races = ParseRaces(lines);
        var times = races.Select(GetChargeTimes);
        return times
            .Select(t => (int)(t.high - t.low + 1))
            .Aggregate(1, (a, b) => a * b);
    }

    public long Part2(string[] lines)
    {
        var race = ParseRace(lines);
        var time = GetChargeTimes(race);
        return time.high - time.low + 1;
    }
 
    public static List<(long time, long dist)> ParseRaces(string[] lines)
    {
        var times = ParseValues(lines.First());
        var distances = ParseValues(lines.Last());
        return times.Select((t, i) => (t, distances[i])).ToList();
    }

    public static (long time, long dist) ParseRace(string[] lines)
    {
        var time = ParseValue(lines.First());
        var distance = ParseValue(lines.Last());
        return (time, distance);
    }

    private static List<long> ParseValues(string line)
    {
        return Regex
            .Matches(line, "\\d+")
            .Select(m => long.Parse(m.Value)).ToList();
    }

    private static long ParseValue(string line)
    {
        var longerNumber = string.Join("", Regex
            .Matches(line, "\\d+")
            .Select(m => m.Value));
        return long.Parse(longerNumber);
    }

    public (long low, long high) GetChargeTimes((long time, long distance) race)
    {
        var lowest = 1;
        while(lowest < race.time)
        {
            var dist = (race.time - lowest) * lowest;
            if (dist > race.distance) break;
            lowest++;
        }

        var highest = race.time - 1;
        while(highest >= lowest)
        {
            var dist = (race.time - highest) * highest;
            if (dist > race.distance) break;
            highest--;
        }
        return (lowest, highest);
    }
}