using Pipe;

namespace TestPipe;

public class TestPipeGraph
{
    [Fact]
    public void TestAnimalLocation_TestInput_11()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var pipeGraph = new PipeGraph(lines);
        Assert.Equal((1,1), pipeGraph.Animal);
    }
}