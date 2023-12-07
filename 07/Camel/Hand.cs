namespace Camel;

public partial class Hand : IComparable<Hand>
{
    public List<Card> Cards { get; set; }
    public int BidValue { get; set; }

    public Hand(string line)
    {
        var values = line.Split(" ");
        BidValue = int.Parse(values.Last());
        Cards = values.First().Select(c => new Card(c)).ToList();
    }

    public HandType GetHandType()
    {
        var jokers = Cards.Where(c => c.Sign == 'J').Count();
        var others = Cards.Where(c => c.Sign != 'J');
        var signs = Cards.Select(c => c.Sign).Distinct().ToArray();

        var matches = new Dictionary<int, string>();
        foreach (var sign in signs.Distinct())
        {
            var count = Cards.Where(c => c.Sign == sign).Count();
            if (matches.ContainsKey(count))
            {
                matches[count] += sign;
            }
            else
            {
                matches[count] = sign.ToString();
            }
        }

        if (jokers == 0 || jokers == 5)
        {
            if (matches.ContainsKey(5)) return HandType.FiveKind;

            if (matches.ContainsKey(4)) return HandType.FourKind;
            if (matches.ContainsKey(3))
            {
                if (jokers == 3)
                {

                }
                if (matches.ContainsKey(2)) return HandType.FullHouse;
                else return HandType.ThreeKind;
            }
            if (matches.ContainsKey(2))
            {
                if (matches[2].Length > 1) return HandType.TwoPair;
                else return HandType.OnePair;
            }
            return HandType.HighCard;
        }
        
        if (matches.ContainsKey(4) && jokers > 0) return HandType.FiveKind;

        if (matches.ContainsKey(3))
        {
            if (jokers != 3)
            {
                return jokers == 2 ? HandType.FiveKind : HandType.FourKind;
            }
            else
            {
                return matches.ContainsKey(2) ? HandType.FiveKind : HandType.FourKind;
            }
        }

        if (matches.ContainsKey(2))
        {
            var pairs = matches[2];
            if(pairs.Length > 1)
            {
                return pairs.Contains('J') ? HandType.FourKind : HandType.FullHouse;
            }
            return HandType.ThreeKind;
        }
        return HandType.OnePair;

    }

    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            return 1;
        }
        var hand = GetHandType();
        var otherHand = other.GetHandType();

        if (hand == otherHand)
        {
            for (var i = 0; i < Cards.Count(); i++)
            {
                var self = Cards[i];
                var compare = other.Cards[i];
                if (self.Value == compare.Value) continue;
                return self.Value < compare.Value ? -1 : 1;
            }
            throw new Exception($"Hands are equal? {Cards.Select(c => c.Sign)}");
        }

        return hand < otherHand ? -1 : 1;
    }

    public override string ToString()
    {
        return $"{string.Join("", Cards.Select(c => c.Sign))}";
    }
}
