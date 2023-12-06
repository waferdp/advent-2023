namespace TestBoat;
using Boat;

public class TestBoat
{
    [Fact]
    public void TestParse()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var races = Program.ParseRaces(lines);
        Assert.Equal((15,40), races[1]);
        Assert.Equal(3, races.Count());
    }

    [Fact]
    public void TestChargeTimes()
    {
        var program = new Program();
        var times = program.GetChargeTimes((15, 40));
        Assert.Equal(4, times.low);
        Assert.Equal(11, times.high);
    }
    
    [Fact]
    public void TestInput()
    {
        var program = new Program();
        var lines = File.ReadAllLines("test_input.txt");
        var races = Program.ParseRaces(lines);
        var times = races.Select(program.GetChargeTimes).Select(t => (int) (t.high - t.low + 1)).ToList();
        var expected = new List<int>{4, 8, 9};
        Assert.Equal(expected, times);
        Assert.Equal(288, times.Aggregate(1,(a,b) => a*b));
    }

    [Fact]
    public void TestPart2()
    {
        var program = new Program();
        var lines = File.ReadAllLines("test_input.txt");
        var ways = program.Part2(lines);
        Assert.Equal(71503, ways);
    }
}