namespace Cppia.Runtime;

public class CppiaInstance
{
    public Dictionary<string, object?> Properties { get; } = new();

    public InterpretedClass Class { get; }
    internal object? NativeSuper { get; set; }

    public CppiaInstance(InterpretedClass @class) => Class = @class;
}