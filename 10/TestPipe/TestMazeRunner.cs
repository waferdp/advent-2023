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
}