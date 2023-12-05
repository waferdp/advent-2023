using System.Text.RegularExpressions;

public class Program
{
    private const string mapNamePattern = "[a-z]+-to-[a-z]+";

    public Program(string[] lines)
    {
        Part1(lines);
        Part2(lines);
    }

    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input/input.txt");
        var program = new Program(lines);
    }

    public void Part1(string[] lines)
    {
        var seeds = ParseSeeds(lines.First());

        var namedMaps = ParseMaps(lines);
        var order = namedMaps.Keys; //.Select(m => m.Keys.Single());
        var location = long.MaxValue;
        foreach(var seed in seeds)
        {
            var node = seed;
            foreach(var name in order)
            {
                node = namedMaps[name].GetDestination(node);
            }
            location = long.Min(node, location);
        }
        Console.WriteLine($"Part1: {location}");
    }

    public void Part2(string[] lines)
    {
        var seedRanges = ParseSeedRanges(lines.First());
        var namedMaps = ParseMaps(lines);
        var reverseOrder = namedMaps.Keys.Reverse();

        for(long i = 0; i < long.MaxValue; i++)
        {
            var node = i;
            foreach(var name in reverseOrder)
            {
                node = namedMaps[name].GetSource(node);
            }
            if(seedRanges.Any(sr => sr.IsMatch(node)))
            {
                Console.WriteLine($"Part 2: {i}");
                break;
            }
            
        }
    }

    public List<long> ParseSeeds(string line)
    {
        return Regex.Matches(line, "\\d+").Select(m => long.Parse(m.Value)).ToList();
    }

    public List<SmartRange> ParseSeedRanges(string line)
    {
        var numbers = Regex.Matches(line, "\\d+").Select(m => long.Parse(m.Value)).ToList();
        var ranges = new List<SmartRange>();
        for(var i = 0; i < numbers.Count(); i += 2)
        {
            var start = numbers[i];
            var range = numbers[i+1];
            ranges.Add(new SmartRange(start, range));
        }
        return ranges;
    }

    public List<(int, int)> GetChapters(List<int> ix, int total)
    {
        var chapters = new List<(int, int)>();
        for(var i = 0; i < ix.Count; i++)
        {
            var start = ix[i];
            var amount =  (i == ix.Count - 1 ? total : ix[i+1] - 1) - start;
            chapters.Add((start, amount));
        }
        return chapters;
    }

    public Dictionary<string, SmartMap> ParseMaps(string[] lines)
    {
        var indexes = lines
            .Select((line, index) => Regex.IsMatch(line, mapNamePattern) ? index : -1)
            .Where(i => i > -1);

        var chapters = GetChapters(indexes.ToList(), lines.Count());
        
        var maps = chapters
            .Select(chapter => 
                ParseX(lines.Skip(chapter.Item1).Take(chapter.Item2).ToArray()));

        var namedMaps = new Dictionary<string, SmartMap>();
        foreach(var map in maps)
        {
            var key = map.Keys.Single();
            namedMaps[key] = map[key];
        }
        return namedMaps;
    }

    // The lines of one mapping, first line is the map name
    public Dictionary<string, SmartMap> ParseX(string[] lines)
    {
        var mapName = Regex.Match(lines.First(), mapNamePattern).Value;
        var smartMap = new SmartMap();
        foreach(var line in lines.Skip(1))
        {
            var parsed = ParseLine(line);
            smartMap.Add(parsed.dest, parsed.src, parsed.rng);
        }
        var namedMap = new Dictionary<string, SmartMap>();
        namedMap[mapName] = smartMap;

        return namedMap;
    }

    public (long dest, long src, long rng) ParseLine(string line)
    {
        var numbers = Regex.Matches(line, "\\d+").Select(m => long.Parse(m.Value)).ToArray();
        var dest = numbers[0];
        var src = numbers[1];
        var rng = numbers[2];

        return (dest, src, rng);
    }

    private static Dictionary<int, int> PrepDict()
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < 100; i++)
        {
            dict[i] = i;
        }
        return dict;
    }
}
