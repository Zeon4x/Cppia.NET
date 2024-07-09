using System.Collections;
using System.Reflection;
using Cppia.Instructions;
using Cppia.Runtime;
using Cppia.Std;
using Cppia.Std.Exceptions;

namespace Cppia;

public class CppiaRuntime
{
    private readonly Dictionary<string, IClass> _classes = new();
    private readonly Dictionary<string, CppiaEnum> _enums = new();
    private readonly Dictionary<string, Delegate> _globals = new();

    public CppiaRuntime()
    {
        RegisterType<EnumValue>("::hx::EnumBase");
        RegisterType<CppiaException>("haxe.Exception");
        RegisterType<ValueException>("haxe.ValueException");

        RegisterType<List<int>>("Array.int");
        RegisterExtensionMethods<CppiaArray>("Array.int");
    }

    public IClass? GetClass(string fullName)
    {
        if(_classes.ContainsKey(fullName))
            return _classes[fullName];
        return null;
    }

    public CppiaEnum? GetEnum(string name)
    {
        if(_enums.ContainsKey(name))
            return _enums[name];
        return null;
    }

    /// <returns>Main method instruction</returns>
    public CppiaInstruction? Load(string fileName) => Load(File.OpenRead(fileName));
    
    /// <returns>Main method instruction</returns>
    public CppiaInstruction? Load(byte[] bytes) => Load(new MemoryStream(bytes));
    
    /// <returns>Main method call instruction</returns>
    public CppiaInstruction? Load(Stream stream)
    {
        var file = new CppiaFile(stream);
        var classes = file.CppiaTypes.OfType<CppiaClass>()
            .Where(c => !_classes.ContainsKey(c.Name))
            .Select(c => new InterpretedClass(c, this))
            .ToArray();

        // Add types
        foreach (var @class in classes) _classes.Add(@class.Name, @class);
        foreach (var @enum in file.CppiaTypes.OfType<CppiaEnum>())
            _enums.Add(@enum.Name, @enum);
        
        // Initialize class varibles
        foreach (var @class in classes)
            @class.Initialize();
        return file.Main;
    }

    public void HotReload(string fileName) => File.OpenRead(fileName);
    public void HotReload(byte[] bytes) => new MemoryStream(bytes);
    public void HotReload(Stream stream)
    {
        var file = new CppiaFile(stream);
        foreach (var type in file.CppiaTypes)
        {
            if(type is CppiaClass @class 
                && GetClass(@class.Name) is InterpretedClass interpretedClass)
            {
                foreach (CppiaMethod method in @class.GetMethods())
                {
                    if( _classes[@class.Name].GetMethod(method.Name) is InterpretedMethod interpretedMethod)
                        interpretedMethod.ReplaceCppiaMethod(method);
                }
            }
        }
    }

    public void RegisterType(Type type, string? customName = null)
    {
        if(customName is null)
            customName = type.Name;

        _classes.Add(customName, new NativeClass(type, customName));
    }

    public void RegisterType<T>(string? customName = null) => RegisterType(typeof(T), customName);

    public void RegisterGlobal(string name, Delegate @delegate)
    {
        _globals.Add(name, @delegate);
    }

    public void RegisterExtensionMethods(string className, Type type)
    {
        if(_classes.TryGetValue(className, out IClass @class) && @class is NativeClass nativeClass)
        {
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                nativeClass.AssignDynamicMethod(method.Name, new ExtensionMethod(method));
            }
        }
    }

    public void RegisterExtensionMethods<T>(string className) => RegisterExtensionMethods(className, typeof(T));

    internal object? Execute(FunctionInstruction function, object? thisObj, object?[] args)
    {
        var context = new Context(this, thisObj as CppiaInstance);
        for (int i = 0; i < function.Arguments.Count; i++)
        {
            var argument = function.Arguments[i];
            context.Varibles.Add(argument.Id, args[i]);
        }
        return function.Invoke(context);
    }

    internal object? InvokeGlobal(string name, params object?[] args)
    {
        if(!_globals.ContainsKey(name))
            throw new Exception("Global not found: " + name);
        return _globals[name].DynamicInvoke(args);
    }
}