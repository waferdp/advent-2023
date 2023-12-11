namespace Pipe;

public class MazeRunner
{
    private Matrix2d<(int x, int y)> visited;
    private readonly Matrix2d<int> distance;
    private readonly PipeGraph graph;

    private Queue<(int, int)> queue;

    public MazeRunner(string[] lines)
    {
        visited = Matrix2d<(int, int)>.Empty((0, 0));
        distance = Matrix2d<int>.Empty(0);
        graph = new PipeGraph(lines);
        queue = new Queue<(int, int)>();
    }


    public void FindAllRoutes()
    {
        FindRoutes((-1,-1));
    }

    public void FindRoutes((int x, int y) goal)
    {
        queue.Enqueue(graph.Animal);
        visited[graph.Animal.x, graph.Animal.y] = (0, 0);
        distance[graph.Animal.x, graph.Animal.y] = 0;
        var pos = graph.Animal;
        while (queue.Any() && pos != goal)
        {
            pos = queue.Dequeue();
            var dist = distance.Get(pos);
            var neighbors = GetNeighbors(pos);
            foreach (var neighbor in neighbors)
            {
                visited[neighbor.x, neighbor.y] = pos;
                distance[neighbor.x, neighbor.y] = dist + 1;
                queue.Enqueue(neighbor);
            }
        }
    }

    public List<(int, int)> FindLoop()
    {
        var start = graph.Animal;
        FindAllRoutes();
        var goal = FindLongestRoutePos();
        var route = Backtrack(goal, start).Skip(1);
        visited = Matrix2d<(int, int)>.Empty((0,0));
        foreach(var pos in route)
        {
            visited[pos.x, pos.y] = graph.Animal;
        }
        FindRoutes(goal);
        return route.Concat(Backtrack(goal, start)).ToList();
    }

    public (int x, int y) FindLongestRoutePos()
    {
        var longest = 0;
        var pos = (0, 0);
        for (var y = distance.MinY; y <= distance.MaxY; y++)
        {
            for (var x = distance.MinX; x <= distance.MaxX; x++)
            {
                if (distance.Get(x, y) > longest)
                {
                    pos = (x, y);
                    longest = distance.Get(x, y);
                }
            }
        }
        return pos;
    }

    public List<(int x, int y)> Backtrack((int x, int y) from, (int x, int y) to)
    {
        if (!visited.ContainsXY(from) || !visited.ContainsXY(to))
        {
            throw new Exception($"Invalid position arguments: {from}, {to}");
        }
        var nodes = new List<(int x, int y)>(){from};
        while (nodes.Last() != to)
        {
            nodes.Add(visited.Get(nodes.Last()));
        }
        return nodes;
    }

    public int FindLongestRouteDistance()
    {
        var longest = 0;
        for (var y = distance.MinY; y <= distance.MaxY; y++)
        {
            for (var x = distance.MinX; x <= distance.MaxX; x++)
            {
                longest = Math.Max(distance.Get(x, y), longest);
            }
        }
        return longest;
    }

    private List<(int x, int y)> GetNeighbors((int x, int y) pos)
    {
        return graph
            .GetAllowedMoves(pos)
            .Select(m => m.Destination)
            .Where(d => !visited.ContainsXY(d))
            .ToList();
    }
}