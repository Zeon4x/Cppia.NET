using Cppia.Runtime;

namespace Cppia.Instructions;

public class CallGlobalInstruction : BaseCallInstruction
{
    public string Field { get; }
    
    public CallGlobalInstruction(CppiaFile file, CppiaReader reader)
    {
        Field = file.Strings[reader.ReadInt()];
        ReadArguments(file, reader);
    }

    public override object? Execute(Context context)
    {
        return context.Runtime.InvokeGlobal(Field, GetArguments(context));
    }
}