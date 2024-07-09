using Cppia.Instructions;
using Cppia.Runtime;

namespace Cppia.Runtime;

public class CppiaFunction : IMethod
{
    public string Name => string.Empty;

    public bool IsStatic => true;

    private readonly FunctionInstruction _function;
    private readonly CppiaRuntime _runtime;
    
    public CppiaFunction(FunctionInstruction function, CppiaRuntime runtime)
    {
        _function = function;
        _runtime = runtime;
    }
    
    public object? Invoke(object? instance, params object?[] arguments)
    {
        return _runtime.Execute(_function, instance, arguments);
    }
}
