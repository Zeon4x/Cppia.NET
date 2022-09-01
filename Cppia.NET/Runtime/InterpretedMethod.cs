using Cppia.Instructions;
namespace Cppia.Runtime;

public class InterpretedMethod : IMethod
{
    private CppiaMethod _method;
    private CppiaRuntime _runtime;

    public InterpretedMethod(CppiaMethod m, CppiaRuntime runtime)
    {
        _method = m;
        _runtime = runtime;
    }

    public string Name => _method.Name;

    public bool IsStatic => _method.IsStatic;

    public object? Invoke(object? instance, params object?[] parameters)
    {
        if(_method.Body is not FunctionInstruction function)
            throw new Exception("Cannot invoke method without body");

        if(!IsStatic && instance is null)
            throw new NullReferenceException("Cannot invoke not static method without instance");

        return _runtime.Execute(function, instance, parameters);
    }
}