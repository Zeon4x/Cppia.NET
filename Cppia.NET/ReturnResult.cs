namespace Cppia;

public struct ReturnResult
{
    public object? Value { get; }

    public ReturnResult(object? value)
    {
        Value = value;
    }
}
