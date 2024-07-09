namespace Cppia.Runtime;

public class InterpretedVarible : IVarible
{
    public string Name => _varible.Name;
    public bool IsStatic => _varible.IsStatic;

    private readonly InterpretedClass _declaredClass;
    private readonly CppiaVarible _varible;
    private readonly CppiaRuntime _runtime;

    public InterpretedVarible(CppiaVarible varible, CppiaRuntime runtime, InterpretedClass declaredClass)
    {
        _varible = varible;
        _runtime = runtime;
        _declaredClass = declaredClass;
    }

    internal void Initialize()
    {
        if(_varible.Init is not null)
        {
            var context = new Context(_runtime, null);
            _staticValue = _varible.Init.Execute(context);
        }
    }

    private object? _staticValue;

    public object? GetValue(object? instance)
    {
        if(_varible.ReadAcess == CppiaVarible.Access.Normal)
        {
            if(IsStatic)
                return _staticValue;
            if (instance is CppiaInstance cppiaInstance)
            {
                if (cppiaInstance.Properties.ContainsKey(Name))
                    return cppiaInstance.Properties[Name];
                return null;
            }
            throw new NullReferenceException("Cannot get field value of null");
        }
        else if (_varible.ReadAcess == CppiaVarible.Access.Call)
        {
            if(_declaredClass.GetMethod("get_" + Name) is IMethod method)
                return method.Invoke(instance);
            throw new NullReferenceException($"Property getter not found");
        }
        throw new NotImplementedException();
    }

    public void SetValue(object? instance, object? value)
    {
        if (_varible.WriteAccess == CppiaVarible.Access.Call)
        {
            if(_declaredClass.GetMethod("get_" + Name) is IMethod method)
                method.Invoke(instance,value);
            else
                throw new NullReferenceException($"Property setter not found");
        }
        else
        {
            if(IsStatic)
                _staticValue = value;
            else if(instance is CppiaInstance cppiaInstance)
                cppiaInstance.Properties[Name] = value;
            else
                throw new NullReferenceException("Cannot get field value of null");
        }
    }
}