using Cppia.Runtime;

namespace Cppia.Instructions;

public class CallSuperInstruction : BaseCallInstruction
{
    public string Class { get; }
    public string Field { get; }

    public CallSuperInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
        int argsCount = reader.ReadInt();
        ReadArguments(file, reader, argsCount);
    }

    public override object? Execute(Context context)
    {
        if(context.Runtime.GetClass(Class) is not IClass @class)
            throw new Exception("Class not found: " + Class);
        if(@class.GetMethod(Field) is not IMethod method)
            throw new Exception($"Method {Field} not found in class {Class}");

        return method.Invoke(context.This, GetArguments(context));
    }
}