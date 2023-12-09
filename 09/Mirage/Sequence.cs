using System.Text.RegularExpressions;
namespace Mirage;

public class Sequence
{
    public List<int> Numbers { get; set; } = new List<int>();
    
    public Sequence(string line)
    {
        if(string.IsNullOrEmpty(line))
        {
            return;
        }
        Numbers = line.Split(" ").Select(int.Parse).ToList();
    }

    /// <summary>
    /// Returns a list of sequences starting with this sequence
    /// The last element of the sequence will contain all zeroes
    /// </summary>
    /// <returns></returns>
    public static List<Sequence> DrillDown(Sequence sequence)
    {
        var sequences = new List<Sequence>() { sequence };
        var current = sequence;
        while(!current.IsAllZero())
        {
            current = current.GetNext();
            sequences.Add(current);
        }
        return sequences;
    }

    public static long Extrapolate(List<Sequence> sequences)
    {
        var extrapolations = new List<int>() {0};
        for(var i = 1; i < sequences.Count; i++)
        {
            var last = sequences[sequences.Count - 1 - i].Numbers.Last();
            extrapolations.Add(last + extrapolations.Last());
        }
        return extrapolations.Last();
    }

    public static long Prepolate(List<Sequence> sequences)
    {
        var prepolations = new List<int>() {0};
        for(var i = 1; i < sequences.Count; i++)
        {
            var first = sequences[sequences.Count - 1 - i].Numbers.First();
            prepolations.Add(first - prepolations.Last());
        }
        return prepolations.Last();
    }

    public Sequence GetNext()
    {
        var next = new Sequence(string.Empty);
        for(var i = 0; i < Numbers.Count() - 1; i++)
        {
            var a = Numbers[i];
            var b = Numbers[i+1];
            next.Numbers.Add(b-a);
        }
        return next;
    }

    public bool IsAllZero()
    {
        return Numbers.All(n => n == 0);
    }
}