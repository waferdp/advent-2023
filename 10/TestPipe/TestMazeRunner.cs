using Pipe;

namespace TestPipe;

public class TestMazeRunner
{
    [Fact]
    public void TestFindLongestRouteDistance_TestInput_Distance4()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var mazeRunner = new MazeRunner(lines);

        mazeRunner.FindAllRoutes();
        var distance = mazeRunner.FindLongestRouteDistance();
        Assert.Equal(4, distance);
    }

    [Fact]
    public void TestFindLongestRouteDistance_TestInput2_Distance8()
    {
        var lines = File.ReadAllLines("test_input2.txt");
        var mazeRunner = new MazeRunner(lines);

        mazeRunner.FindAllRoutes();
        var distance = mazeRunner.FindLongestRouteDistance();
        Assert.Equal(8, distance);
    }

    [Fact]
    public void TestFindLoop_TestInput_Correct()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var mazeRunner = new MazeRunner(lines);
        var expected = new string[] { ".....", ".***.", ".*.*.", ".***.", "....." };

        var loop = mazeRunner.FindLoop();

        var visited = Matrix2d<string>.Empty(".");
        visited.Set(0, 0, ".");
        visited.Set(4, 4, ".");
        foreach (var (x, y) in loop)
        {
            visited[x, y] = "*";
        }
        Assert.Equal(expected, visited.AsStrings());
    }

    [Fact]
    public void TestInsideLoop_TestInput1_Gets1()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var mazeRunner = new MazeRunner(lines);
        var loop = mazeRunner.FindLoop();
        var actual = mazeRunner.Graph.NodesInLoop(loop);
        Assert.Equal(1, actual);
    }

    [Fact]
    public void TestInsideLoop_TestInput3_Gets4()
    {
        var lines = File.ReadAllLines("test_input3.txt");
        var mazeRunner = new MazeRunner(lines);
        var loop = mazeRunner.FindLoop();
        var actual = mazeRunner.Graph.NodesInLoop(loop);
        Assert.Equal(4, actual);
    }    

    [Fact]
    public void TestInsideLoop_TestInput4_Gets8()
    {
        var lines = File.ReadAllLines("test_input4.txt");
        var mazeRunner = new MazeRunner(lines);
        var loop = mazeRunner.FindLoop();
        var actual = mazeRunner.Graph.NodesInLoop(loop);
        Assert.Equal(8, actual);
    }    
}