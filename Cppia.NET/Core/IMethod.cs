namespace Cppia.Runtime;

public interface IMethod
{
    string Name { get; }
    bool IsStatic { get; }
    object? Invoke(object? instance, params object?[] parameters);
}