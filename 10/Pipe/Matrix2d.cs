namespace Pipe;

public class Matrix2d<T>
{
    public T DefaultValue { get; private set; }
    public int MinX { get; private set; } = 0;
    public int MaxX { get; private set; } = 0;
    public int MinY { get; private set; } = 0;
    public int MaxY { get; private set; } = 0;
    private Dictionary<int, Dictionary<int, T>> matrix;

    public Matrix2d(List<List<T>> lines, T defaultValue)
    {
        matrix = new Dictionary<int, Dictionary<int, T>>();
        for (int y = 0; y < lines.Count(); y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Count(); x++)
            {
                var elem = line[x];
                this.Set(x, y, elem);
            }
        }
        DefaultValue = defaultValue;
    }

    public static Matrix2d<T> Empty(T defaultValue)
    {
        var emptyInput = new List<List<T>>();
        return new Matrix2d<T>(emptyInput, defaultValue);
    }

    public void Set(int x, int y, T value)
    {
        if (!matrix.ContainsKey(y))
        {
            matrix[y] = new Dictionary<int, T>();
        }
        matrix[y][x] = value;
        MinX = Math.Min(MinX, x);
        MaxX = Math.Max(MaxX, x);
        MinY = Math.Min(MinY, y);
        MaxY = Math.Max(MaxY, y);
    }

    public T Get(int x, int y)
    {
        try
        {
            return matrix[y][x];
        }
        catch (KeyNotFoundException)
        {
            return DefaultValue;
        }
    }

    public T Get((int x, int y) pos)
    {
        return Get(pos.x, pos.y);
    }

    public T this[int x, int y]
    {
        get
        {
            return Get(x, y);
        }
        set
        {
            Set(x, y, value);
        }
    }

    public (int x, int y)? Find(T value)
    {
        for (var y = MinY; y <= MaxY; y++)
        {
            for (var x = MinX; x <= MaxX; x++)
            {
                var atXy = Get(x, y);
                if (atXy is not null && atXy.Equals(value)) return (x, y);
            }
        }
        return null;
    }

    public bool Contains(int x, int y)
    {
        return matrix.ContainsKey(y) && matrix[y].ContainsKey(x);
    }

    public bool ContainsXY((int, int) pos2d)
    {
        return Contains(pos2d.Item1, pos2d.Item2);
    }

    // public int MinX { get { return matrix.Values.FirstOrDefault()?.Keys.Min() ?? 0; } }

    // public int MaxX { get { return matrix.Values.FirstOrDefault()?.Keys.Max() ?? 0; } }

    // public int MinY { get { return matrix.Keys.Min(); } }

    // public int MaxY { get { return matrix.Keys.Max(); } }

    public int Width { get { return matrix.Values.FirstOrDefault()?.Count() ?? 0; } }

    public int Height { get { return matrix.Values.Count(); } }

    public string[] AsStrings(bool includeEmpty = false)
    {
        if(!includeEmpty) 
        {
            return matrix.Keys
                .Select(y => string
                    .Join("", matrix[y].Keys
                        .Select(x => Get(x, y)).ToList()))
                .ToArray();
        }
        var strings = new List<string>();
        for(var y = MinY; y <= MaxY; y++)
        {
            var row = string.Empty;
            for(var x = MinX; x <= MaxX; x++)
            {
                row += Get(x,y);
            }
            strings.Add(row);
        }
        return strings.ToArray();
    }

    public override string ToString()
    {
        return string.Join('\n', AsStrings());
    }
}
