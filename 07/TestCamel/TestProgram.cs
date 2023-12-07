using Camel;

namespace TestCamel;

public class TestProgram
{
    [Fact]
    public void TestInput_GetsCorrectWinnings()
    {
        var lines = File.ReadAllLines("test_input.txt");
        var result = Program.Part1(lines);
        Assert.Equal(5905, result);
    }

    [Fact]
    public void SortInput2_GetsCorrectOrder()
    {
        var lines = File.ReadAllLines("test_input2.txt");
        var hands = lines.Select(line => new Hand(line)).ToList();
        hands.Sort();
        hands.Reverse();

        var expected = new string[]
        {
            "AAAAA",
            "22222",
            "AAAAK",
            "22223",
            "AAAKK",
            "22233",
            "AAAKQ",
            "AAKQJ",
            "22234",
            "AAKKQ",
            "22334",
            "AKQJT",
            "22345",
            "23456"
        };
        Assert.Equal(expected, hands.Select(h => h.ToString()).ToArray());
    }

    // [Fact]
    // public void TestInput2_GetsCorrectWinnings()
    // {
    //     var lines = File.ReadAllLines("test_input2.txt");
    //     var result = Program.Part1(lines);
    //     Assert.Equal(1343, result);
    // }
}