// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

namespace Mirage;

public class Program
{
    public long Part1(string[] lines)
    {
        return lines
        .Select(line =>Sequence.Extrapolate(Sequence.DrillDown(new Sequence(line))))
        .Sum();
    }

    public long Part2(string[] lines)
    {
        return lines
        .Select(line =>Sequence.Prepolate(Sequence.DrillDown(new Sequence(line))))
        .Sum();
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


