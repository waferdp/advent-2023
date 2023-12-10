namespace Pipe;

public class Program
{
    public int Part1(string[] lines)
    {
        var mazeRunner = new MazeRunner(lines);

        mazeRunner.FindAllRoutes();
        return mazeRunner.FindLongestRouteDistance();

    }

    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var part1 = new Program().Part1(lines);

        Console.WriteLine($"Part 1: {part1}");
    }
}