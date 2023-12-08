using Wasteland;

namespace TestWasteland;

public class TestMap
{
    [Fact]
    public void TestNavigate_TestInput_2steps()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var map = new Map(lines.Skip(2).ToArray());
        var path = lines[0].Select(c => (Choice) c);
        var steps = map.Navigate(path, "AAA", "ZZZ");
        Assert.Equal(2, steps);
    }

    [Fact]
    public void TestPart1_TestInput2_6steps()
    {
        var lines = File.ReadAllLines("test_input2.txt");
        var steps = new Program().Part1(lines);
        Assert.Equal(6, steps);
    }

    [Fact]
    public void TestPart2_TestInput3_6steps()
    {
        var lines = File.ReadAllLines("test_input3.txt");
        var steps = new Program().Part2(lines);
        Assert.Equal(6, steps);
    }
}