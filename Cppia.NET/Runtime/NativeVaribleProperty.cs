using System.Reflection;

namespace Cppia.Runtime;

public class NativeVaribleProperty : IVarible
{
    public string Name { get; }

    public bool IsStatic => _property.GetMethod?.IsStatic ?? _property.SetMethod!.IsStatic;

    private readonly PropertyInfo _property;

    public NativeVaribleProperty(PropertyInfo property)
    {
        _property = property;
        if(property.GetCustomAttribute<CppiaFieldAttribute>() is CppiaFieldAttribute attribute)
            Name = attribute.Name;
        else
            Name = _property.Name;
    }

    public object? GetValue(object? instance)
    {
        return _property.GetValue(instance);
    }

    public void SetValue(object? instance, object? value)
    {
        _property.SetValue(instance, value);
    }
}