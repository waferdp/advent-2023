using Camel;

namespace TestCamel;

public class TestHand
{
    [Fact]
    public void TestHandConstructor()
    {
        var line = "32T3K 765";
        var hand = new Hand(line);
        Assert.Equal(3, hand.Cards.First().Value);
        Assert.Equal(13, hand.Cards.Last().Value);
        Assert.Equal(765, hand.BidValue);
    }

    [Fact]
    public void TestRanking_OnePairVsTwoPair_OnePairLower()
    {
        var onePair = new Hand("32T3K 765");
        var twoPair = new Hand("KK677 28");
        Assert.Equal(-1, onePair.CompareTo(twoPair));
    }

    [Fact]
    public void TestRanking_BothTwoPairs_BetterCardWins()
    {
        var a = new Hand("KK677 28");
        var b = new Hand("KTAAT 220");
        Assert.Equal(1, a.CompareTo(b));
    }

    [Fact]
    public void TestFullHouses_NumberWins()
    {
        var one = new Hand("77888 1");
        var two = new Hand("77788 1");
        Assert.Equal(1, one.CompareTo(two));
    }

    [Fact]
    public void TestGetHandType_22234_ThreeKind()
    {
        var hand = new Hand("22234 1");
        Assert.Equal(HandType.ThreeKind, hand.GetHandType());
    }

    [Fact]
    public void TestGetHandType_AAAAK_FourKind()
    {
        var hand = new Hand("AAAAK 1");
        Assert.Equal(HandType.FourKind, hand.GetHandType());
    }

    [Fact]
    public void TestGetHandType_AAKQJ_ThreeKind()
    {
        var hand = new Hand("AAKQJ 1");
        Assert.Equal(HandType.ThreeKind, hand.GetHandType());
    }

    [Fact]
    public void TestGetHandType_22334_TwoPair()
    {
        var hand = new Hand("22334 1");
        Assert.Equal(HandType.TwoPair, hand.GetHandType());
    }
}