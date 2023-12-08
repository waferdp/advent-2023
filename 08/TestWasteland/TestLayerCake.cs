using Wasteland;

namespace TestWasteland;

public class TestLayerCake
{
    [Fact]
    public void TestGetLcm_Known_ReturnsCorrect()
    {
        var numbers = new long[]{10,12,15,75};
        var lcm = numbers.Aggregate((a, b) => MathLcm.Lcm(a, b));
        Assert.Equal(300, lcm);
    }
}