using Challenges.Helpers;
using System;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/binary-search-tree/96025
/// </summary>
internal class BinarySearchTree : IStartable
{
    public void Start()
    {
        Node n1 = new Node(1, null, null);
        Node n3 = new Node(3, null, null);
        Node n2 = new Node(2, n1, n3);

        Console.WriteLine(Contains(n2, 3));
    }

    public static bool Contains(Node root, int value)
    {
        Node currentRoot = root;
        while (currentRoot != null)
        {
            if (value == currentRoot.Value)
                return true;
            else if (value < currentRoot.Value)
                currentRoot = currentRoot.Left;
            else
                currentRoot = currentRoot.Right;
        }
        return false;
    }
}

public class Node
{
    public int Value { get; set; }

    public Node Left { get; set; }

    public Node Right { get; set; }

    public Node(int value, Node left, Node right)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}
