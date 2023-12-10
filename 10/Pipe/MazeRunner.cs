namespace Pipe;

public class MazeRunner
{
    private readonly Matrix2d<(int x, int y)> visited;
    private readonly Matrix2d<int> distance;
    private readonly PipeGraph graph;

    private Queue<(int, int)> queue;

    public MazeRunner(string[] lines)
    {
        visited = Matrix2d<(int x, int y)>.Empty((0, 0));
        distance = Matrix2d<int>.Empty(0);
        graph = new PipeGraph(lines);
        queue = new Queue<(int, int)>();
    }


    public void FindAllRoutes()
    {
        queue.Enqueue(graph.Animal);
        visited[graph.Animal.x, graph.Animal.y] = (0, 0);
        distance[graph.Animal.x, graph.Animal.y] = 0;
        while (queue.Any())
        {
            var pos = queue.Dequeue();
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

    public (int x, int y) FindLongestRoutePos()
    {
        var longest = 0;
        var pos = (0, 0);
        for (var y = distance.MinY; y < distance.MaxY; y++)
        {
            for (var x = distance.MinX; x < distance.MaxX; x++)
            {
                if(distance.Get(x, y) > longest)
                {
                    pos = (x, y);
                    longest = distance.Get(x, y);
                }
            }
        }
        return pos;
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