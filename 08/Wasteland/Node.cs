namespace Wasteland;
public class Node
{
    public string Name { get; set; }
    public string Left { get; set; }
    public string Right { get; set; }

    public Node(string name, string left, string right)
    {
        Name = name;
        Left = left;
        Right = right;
    }

    public string GetChoice(Choice choice)
    {
        if (choice == Choice.Left)
        {
            return Left;
        }
        return Right;
    }
}
