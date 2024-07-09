using System.Reflection;

namespace Cppia.Runtime;

public class ExtensionMethod : NativeMethod
{
    public ExtensionMethod(MethodBase method) 
        : base(method) {}

    public override object? Invoke(object? instance, params object?[] parameters)
    {
        return base.Invoke(instance, parameters.Prepend(instance).ToArray());
    }
}
