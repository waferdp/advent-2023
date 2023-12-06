using System.Text.RegularExpressions;

public class Program
{
    private static Dictionary<string, string> words;

    public Program()
    {
        words = new Dictionary<string, string>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };
    }

    public static void Main(string[] args)
    {
        new Program();
        var lines = File.ReadAllLines("input\\input.txt");
        var numbers = lines.Select(l => GetLineValue(l)).ToList();
        Console.WriteLine(numbers.Sum());
    }

    private static int GetLineValue(string line)
    {
        var numbers = GetNumbers(line);
        return int.Parse(numbers.First() + numbers.Last());
    }

    private static List<string> GetNumbers(string line)
    {
        var numbers = line;
        foreach (var word in words.Keys)
        {
            while(true)
            {
                var index = numbers.IndexOf(word);
                if(index < 0) break;
                numbers = numbers.Remove(index+1, 1);
                numbers = numbers.Insert(index+1, words[word]);
            }
        }
        var result = numbers.Where(n => Char.IsDigit(n)).Select(n => n.ToString()).ToList();
        Console.WriteLine($"{line}: {string.Join("", result)} -> {result.First() + result.Last()}");

        // for(var i = 0; i < line.Count(); i++)
        // {
        //     var current = line[i];
        //     if (Char.IsDigit(current))
        //     {
        //         result.Add(current.ToString());
        //         word = string.Empty;
        //         continue;
        //     }
        //     word += current;

        //     if(words.Keys.Any(w => word.Contains(w)))
        //     {
        //         var key = words.Keys.First(w => word.Contains(w));
        //         result.Add(words[key]);
        //         word = string.Empty;
        //     }
        // }
        
        return result;
    }

    

}

