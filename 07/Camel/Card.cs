namespace Camel;

public class Card
{

    public char Sign { get; private set; }

    public int Value { get; private set; }

    public Card(char sign)
    {
        Sign = sign;
        Value = GetValue(sign);
    }

    private int GetValue(char sign)
    {
        if (char.IsNumber(sign))
        {
            return int.Parse(sign.ToString());
        }
        else
        {
            switch(sign)
            {
                case 'J': return 1;
                case 'T': return 10;
                //case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
            }
        }
        throw new Exception($"Unknown card {sign}");
    }

    public override string ToString() 
    {
        return Sign.ToString();
    }
}