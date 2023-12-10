namespace Pipe;

public class AllowedMoves
{
    public static readonly string[] NorthAllowed = 
    {
            "|",
        "L",
        "J",
        "S"
    };

    public static readonly string[] EastAllowed = 
    {
        "-",
        "L",
        "F",
        "S"
    };

    public static readonly string[] SouthAllowed = 
    {
        "|",
        "7",
        "F",
        "S"
    };

    public static readonly string[] WestAllowed = 
    {
        "-",
        "J",
        "7",
        "S"
    };
}
    