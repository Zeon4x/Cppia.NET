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
        var value = Function.Execute(context);
        if (value is IMethod method)
        {
            var args = GetArguments(context);
            return method.Invoke(null, args);
        }
        throw new NotImplementedException();
    }
}