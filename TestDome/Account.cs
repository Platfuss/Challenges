using Challenges.Helpers;
using System;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/account/96016
/// </summary>
public class Account : IStartable
{
    public void Start()
    {
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }

    [Flags]
    public enum Access
    {
        Delete = 1,
        Publish = 2,
        Submit = 4,
        Comment = 8,
        Modify = 16,
        Writer = Submit | Modify,
        Editor = Delete | Publish | Comment,
        Owner = Writer | Editor
    }

}
