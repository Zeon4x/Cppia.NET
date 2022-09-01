namespace Cppia.Runtime;

public interface IVarible
{
    string Name { get; }
    bool IsStatic { get; }
    object? GetValue(object? instance);
    void SetValue(object? instance, object? value);
}