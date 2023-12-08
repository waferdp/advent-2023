namespace Wasteland;

public class MathLcm
{
    public static long Gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static long Lcm(long a, long b)
    {
        return a / Gcf(a, b) * b;
    }
}