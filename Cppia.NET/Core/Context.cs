namespace Cppia.Runtime;

public class Context
{
    public CppiaRuntime Runtime { get; }

    public Dictionary<int,object?> Varibles { get; } = new();

    public CppiaInstance? This { get; }

    public Context(CppiaRuntime runtime, CppiaInstance? thisObj = null)
    {
        Runtime = runtime;
        This = thisObj;
    }
}
