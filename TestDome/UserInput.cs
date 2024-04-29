using Challenges.Helpers;
using System;
using System.Collections.Generic;

namespace Challenges.TestDome;

/// <summary>
/// https://www.testdome.com/questions/c-sharp/user-input/96008
/// User interface contains two types of user input controls: TextInput, which accepts all characters
///and NumericInput, which accepts only digits.
///Implement the class TextInput that contains:
///• Public method void Add(char c) - adds the given character to the current value
///• Public method string GetValue() - returns the current value
///Implement the class NumericInput that:
///• Inherits TextInput
///• Overrides the Add method so that each non-numeric character is ignored
///For example, the following code should output "10":
///TextInput input = new NumericInput();
///input.Add('1');
///input.Add('a');
///input.Add('0');
///Console.WriteLine(input.GetValue());
/// </summary>

internal class UserInput : IStartable
{
    public void Start()
    {
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');
        Console.WriteLine(input.GetValue());
    }
}

public class TextInput
{
    protected List<char> value = new();
    public virtual void Add(char c)
    {
        value.Add(c);
    }

    public string GetValue()
    {
        return new string(value.ToArray());
    }
}

public class NumericInput : TextInput
{
    public override void Add(char c)
    {
        if (char.IsDigit(c))
            base.Add(c);
    }
}
