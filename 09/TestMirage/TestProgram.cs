using Mirage;

namespace TestMirage;
public class TestProgram
{
    [Fact]
    public void TestPart1_TestInput_Correct()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var number = new Program().Part1(lines);
        Assert.Equal(114, number);
    }

    [Fact]
    public void TestPart2_TestInput_Correct()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var number = new Program().Part2(lines);
        Assert.Equal(2, number);

    }
}