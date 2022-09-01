

using Cppia.Runtime;

namespace Cppia.Instructions;

public class CallSuperNewInstruction : BaseCallInstruction
{
    public string ClassName { get; }

    public CallSuperNewInstruction(CppiaFile file, CppiaReader reader)
    {
        ClassName = file.Types[reader.ReadInt()];
        int argsCount = reader.ReadInt();
        ReadArguments(file, reader, argsCount);
    }

    public override object? Execute(Context context)
    {
        var @class = context.Runtime.GetClass(ClassName);
        var parameters = GetArguments(context);
        
        if(@class is InterpretedClass interpreted)
            interpreted.Constructor!.Invoke(context.This, parameters);
        else if(@class is NativeClass native)
            context.This!.NativeSuper = native.Construct(parameters);
        else
            throw new NullReferenceException("Class not found "+ClassName);
        return null;
    }
}