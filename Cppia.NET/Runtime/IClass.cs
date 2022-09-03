namespace Cppia.Runtime;

public interface IClass
{
    string Name { get; }
    IClass? BaseClass { get; }

    object Construct(params object?[] parameters);
    IVarible? GetVarible(string name);
    IMethod? GetMethod(string name);
    public bool IsOfType(IClass @class);
    void SetDynamicMethod(string name, IMethod function);
}