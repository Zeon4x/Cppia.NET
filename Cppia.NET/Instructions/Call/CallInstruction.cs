using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class CallInstruction : BaseCallInstruction
{
    public CppiaInstruction Function { get; }

    public CallInstruction(CppiaFile file, CppiaReader reader)
    {
        int argsCount = reader.ReadByte();
        Function = ReadInstruction(file,reader);
        ReadArguments(file, reader, argsCount);
    }

    public override object? Execute(Context context)
    {
        object? obj = (Function as BaseFieldInstruction)?.Object;
        var value = Function.Execute(context);
        var args = GetArguments(context);
        object?[] parameters = GetArguments(context);
        if (value is IMethod method)
        {
            return method.Invoke(obj, args);
        }
        else if (value is Delegate function)
        {
            return function.DynamicInvoke(args);
        }
        throw new NotImplementedException();
    }
}