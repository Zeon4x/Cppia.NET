

using Cppia.Runtime;

namespace Cppia.Instructions;

public class NewInstruction : BaseCallInstruction
{
    public string ClassName { get; }

    public NewInstruction(CppiaFile file, CppiaReader reader)
    {
        ClassName = file.Types[reader.ReadInt()];
        ReadArguments(file, reader);
    }

    public override object? Execute(Context context)
    {
        if(context.Runtime.GetClass(ClassName) is not IClass @class)
            throw new NullReferenceException("Class not found: "+ClassName);
        object?[] args = GetArguments(context);
        return @class.Construct(args);
    }
}