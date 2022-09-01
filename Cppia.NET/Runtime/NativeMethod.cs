using System.Reflection;
namespace Cppia.Runtime;

public class NativeMethod : IMethod
{
    public string Name { get; }
    public bool IsStatic => _method.IsStatic;
    private readonly MethodInfo _method;

    public NativeMethod(MethodInfo method)
    {
        _method = method;
        if(_method.GetCustomAttribute<CppiaFieldAttribute>() is CppiaFieldAttribute attribute)
            Name = attribute.Name;
        else
            Name = _method.Name;
    }

    public object? Invoke(object? instance, params object?[] parameters)
    {
        if (instance is CppiaInstance cppiaInstance)
            instance = cppiaInstance.NativeSuper;
        return _method.Invoke(instance, parameters);
    }
}