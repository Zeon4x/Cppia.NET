namespace Cppia.Std.Exceptions;

public class ValueException : CppiaException
{
    public string Value { get; }

    public ValueException(string value)
        : base(value)
    {
        Value = value;
    }

}