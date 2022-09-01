using System.Reflection;

namespace Cppia.Runtime;

public class NativeVaribleField : IVarible
{
    public string Name { get; }

    public bool IsStatic => _field.IsStatic;

    private readonly FieldInfo _field;

    public NativeVaribleField(FieldInfo field)
    {
        _field = field;
        if(field.GetCustomAttribute<CppiaFieldAttribute>() is CppiaFieldAttribute attribute)
            Name = attribute.Name;
        else
            Name = _field.Name;
    }

    public object? GetValue(object? instance)
    {
        return _field.GetValue(instance);
    }

    public void SetValue(object? instance, object? value)
    {
        _field.SetValue(instance, value);
    }
}