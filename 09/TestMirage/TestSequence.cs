using Mirage;

namespace TestMirage;

public class TestSequence
{
    [Fact]
    public void TestParse_Negative_IsNegative()
    {
        var line = "3 2 1 0 -1";
        var sequence = new Sequence(line);
        Assert.Equal(-1, sequence.Numbers.Last());
    }

    [Fact]
    public void TestParse_NegativeDerivate_MinusOne()
    {
        var line = "3 2 1 0 -1";
        var sequence = new Sequence(line);
        Assert.True(sequence.GetNext().Numbers.All(n => n == -1));
    }

    [Fact]
    public void TestDrillDown_FirstOrder_ThreeSequences()
    {
        var line = "0 3 6 9 12 15";
        var sequences = Sequence.DrillDown(new Sequence(line));
        Assert.Equal(3, sequences.Count());
    }

    [Fact]
    public void TestExtrapolate_ThirdOrder_GetsItRight()
    {
        var line = "10 13 16 21 30 45";
        var extrapolation = Sequence.Extrapolate(Sequence.DrillDown(new Sequence(line)));
        Assert.Equal(68, extrapolation);
    }

    [Fact]
    public void TestPrepolate_ThirdOrder_GetsItRight()
    {
        var line = "10 13 16 21 30 45";
        var prepolation = Sequence.Prepolate(Sequence.DrillDown(new Sequence(line)));
        Assert.Equal(5, prepolation);
    }

}