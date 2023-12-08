using System.Text.RegularExpressions;

namespace Wasteland;

public class Map
{
    public Dictionary<string, Node> Nodes { get; set; } = new Dictionary<string, Node>();

    public Map(string[] lines)
    {
        var nodes = lines.Select(line => ParseNode(line));
        Nodes = nodes.ToDictionary(node => node.Name);
    }

    public Node ParseNode(string line)
    {
        var names = Regex.Matches(line, "[A-Z,0-9]{3}").Select(m => m.Value).ToArray();
        return new Node(names[0], names[1], names[2]);
    }

    public int Navigate(IEnumerable<Choice> path, string start, string goal)
    {
        var current = start;
        var steps = 0;
        while(!Regex.IsMatch(current, goal))
        {
            foreach(var choice in path)
            {
                steps++;
                current = Nodes[current].GetChoice(choice);
                if(Regex.IsMatch(current, goal)) break;
            }
        }
        return steps;
    }

    public long NavigateMultiple(IEnumerable<Choice> path, string startPattern, string goalPattern)
    {
        var starts = Nodes.Keys.Where(key => Regex.IsMatch(key, startPattern)).ToArray();
        var steps = starts.Select(start => Navigate(path, start, goalPattern)).ToArray();
        
        var lcm = steps.Select(s => (long) s).Aggregate(MathLcm.Lcm);
        return lcm;
    }
}
