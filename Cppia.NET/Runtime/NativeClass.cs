using System.Reflection;
namespace Cppia.Runtime;

public class NativeClass : IClass
{
    public string Name { get; }

    public IClass? BaseClass => null;

    private readonly Type _type;
    private readonly Dictionary<string, NativeMethod> _methods;
    private readonly Dictionary<string, NativeVaribleField> _fields;
    private readonly Dictionary<string, NativeVaribleProperty> _properties;
    private const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase;
    
    public NativeClass(Type type, string name)
    {
        Name = name;
        _type = type;
        var methods = type.GetMethods();
        _methods = type.GetMethods()
            .Select(m => new NativeMethod(m))
            .Where(m => m.Name != "GetType")
            .ToDictionary(m => m.Name, StringComparer.OrdinalIgnoreCase);
        _fields = type.GetFields()
            .Select(f => new NativeVaribleField(f))
            .ToDictionary(f => f.Name, StringComparer.OrdinalIgnoreCase);
        _properties = type.GetProperties()
            .Select(p => new NativeVaribleProperty(p))
            .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
    }

    public object Construct(params object?[] parameters)
    {
        return Activator.CreateInstance(_type, parameters)!;
    }

    public bool IsOfType(IClass @class)
    {
        if(@class is NativeClass nativeClass)
            return IsOfType(nativeClass._type);
        return false;
    }

    internal bool IsOfType(Type type)
    {
        return type.IsAssignableFrom(_type);
    }

    public IMethod? GetMethod(string name)
    {
        if(_methods.ContainsKey(name))
            return _methods[name];
        return null;
    }

    public IVarible? GetVarible(string name)
    {
        if(_fields.ContainsKey(name))
            return _fields[name];
        else if(_properties.ContainsKey(name))
            return _properties[name];
        return null;
    }
}