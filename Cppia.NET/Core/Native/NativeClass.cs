using System.Reflection;
namespace Cppia.Runtime;

public class NativeClass : IClass
{
    public string Name { get; }

    public IClass? BaseClass => null;

    private readonly Type _type;
    private readonly Dictionary<string, IMethod> _methods = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, NativeVaribleField> _fields;
    private readonly Dictionary<string, NativeVaribleProperty> _properties;
    private const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase;
    
    public NativeClass(Type type, string name)
    {
        Name = name;
        _type = type;

        var methods = type.GetMethods()
            .Where(m => m.Name != "GetType")
            .GroupBy(f => f.Name) // To avoid members with same name
            .Select(m => new NativeMethod(m.First()))
            .OfType<IMethod>().ToArray();
        
        _fields = type.GetFields()
            .GroupBy(f => f.Name)
            .Select(f => new NativeVaribleField(f.First()))
            .ToDictionary(f => f.Name, StringComparer.OrdinalIgnoreCase);

        _properties = type.GetProperties()
            .GroupBy(f => f.Name)
            .Select(p => new NativeVaribleProperty(p.First()))
            .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
    }

    public object Construct(params object?[] parameters)
        => Activator.CreateInstance(_type, parameters);

    public bool IsOfType(IClass @class)
    {
        if(@class is NativeClass nativeClass)
            return AssignableTo(nativeClass._type);
        return false;
    }

    public bool AssignableTo(Type type) => type.IsAssignableFrom(_type);

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
        if(_properties.ContainsKey(name))
            return _properties[name];
        return null;
    }

    public void AssignDynamicMethod(string name, IMethod function)
    {
        _methods[name] = function;
    }
}