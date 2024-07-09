using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class CallStaticInstruction : BaseCallInstruction
{
    public string Class { get; }
    public string Field { get; }

    public CallStaticInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
        ReadArguments(file, reader);
    }

    public override object? Execute(Context context)
    {
        object?[] args = GetArguments(context);
        if(context.Runtime.GetClass(Class) is not IClass @class)
            throw new NullReferenceException("Type not found: "+Class);
        if(@class.GetMethod(Field) is IMethod method)
            return method.Invoke(null, args);
        throw new Exception($"Static method {Field} not found in {Class}");
    }
}