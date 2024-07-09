using System.Collections;
using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Std;

public class Reflect
{
    public static bool HasField(object obj, string field)
    {
        if(obj is null)
            throw new ArgumentNullException(nameof(obj));
        
        if(obj is CppiaInstance instance)
            return instance.Class.GetVarible(field) is not null || instance.Class.GetMethod(field) is not null;
        if(obj is IDictionary dictionary)
            return dictionary.Contains(field);

        var type = obj.GetType();
        return type.GetField(field) is not null || type.GetMethod(field) is not null;
    }

    public static object? Field(object? obj, string name)
    {
        if(obj is IDictionary dictionary)
            return dictionary[name];
        if (obj is CppiaInstance instance)
        {
            if(instance.Class?.GetVarible(name) is IVarible varible)
                return varible.GetValue(obj);
            if(instance.Class?.GetMethod(name) is IMethod method)
                return method;
        }

        if(obj?.GetType().GetField(name) is FieldInfo field)
            return field.GetValue(obj);
        if(obj?.GetType().GetMethod(name) is MethodInfo nativeMethod)
            return nativeMethod;
        
        throw new ArgumentNullException(nameof(name));
    }

    public static void SetField(object? obj, string name, object? value)
    {
        if(obj is IDictionary dictionary)
            dictionary[name] = value;
        else if(obj is CppiaInstance instance)
            instance.Class!.GetVarible(name)?.SetValue(obj, value);
        else if(obj?.GetType().GetField(name) is FieldInfo field)
            field.SetValue(obj, value);
        else
            throw new ArgumentNullException(nameof(name));
    }

    public static object? GetProperty(object? obj, string name)
    {
        if(obj is CppiaInstance instance)
            return instance.Class.GetVarible(name)?.GetValue(obj);
        return obj?.GetType().GetProperty(name)?.GetValue(obj);
    }

    public static void SetProperty(object? obj, string name, object? value)
    {
        if(obj is CppiaInstance instance)
            instance.Class.GetVarible(name)?.SetValue(obj, value);
        else
            obj?.GetType().GetProperty(name)?.SetValue(obj, value);
    }

    public static object? CallMethod(object instance, IMethod method, object?[] parameters)
    {
        return method.Invoke(instance, parameters);
    }

    public static int Compare(object? a, object? b)
    {
        if(a is null && b is null)
            return 0;
        return Comparer.Default.Compare(a, b);
    }

    public static bool CompareMethods(IMethod f1, IMethod f2)
    {
        return f1 is not null && f2 is not null && f1 == f2;
    }

    public static IDictionary Copy(IDictionary dictionary) => new Dictionary<string, object>((Dictionary<string, object>)dictionary);
    
    public static bool DeleteField(IDictionary? dictionary, string field) 
    {
        if(dictionary is null)
            throw new ArgumentNullException(nameof(field));
        dictionary.Remove(field);
        return true;
    }

    public static string[] Fields(IDictionary<string, object> dictionary) => dictionary.Keys.ToArray();

    public static bool IsEnumValue(object? value)
    {
        return value is EnumValue;
    }
    
    public static bool IsFunction(object? function)
    {
        return function is IMethod;
    }

    public static bool IsObject(object? value) 
    {
        return value is not IMethod || value is not IVarible || value is not null;
    }

    public static object MakeVarArgs(IMethod method) => throw new NotSupportedException();
}