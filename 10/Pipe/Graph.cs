namespace Pipe;

public class Graph
{
    private Dictionary<(int, int), List<(int,int)>> nodes;

    public Graph()
    {
        nodes = new Dictionary<(int, int), List<(int, int)>>();
    }
    
    public void AddNode((int, int) node, List<(int, int)> neighbors)
    {
        nodes[node] = neighbors;
    }

    public List<(int x, int y)> GetNeighbors((int, int) node)
    {
        return nodes[node];
    }

    public List<(int x, int y)> GetNeighbors(int x, int y)
    {
        return nodes[(x, y)];
    }

    public int Size()
    {
        return nodes.Count();
    }
}
