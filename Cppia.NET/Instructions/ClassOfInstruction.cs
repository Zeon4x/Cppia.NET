using Cppia.Runtime;

namespace Cppia.Instructions;

public class ClassOfInstruction : CppiaInstruction
{
    public string Class { get; }
    public ClassOfInstruction(CppiaFile file, CppiaReader reader) 
    {
        Class = file.Types[reader.ReadInt()];
    }

    public override object? Execute(Context context)
    {
        if(context.Runtime.GetClass(Class) is not IClass @class)
            throw new Exception("Class not found "+Class);
        return @class;
    }
}