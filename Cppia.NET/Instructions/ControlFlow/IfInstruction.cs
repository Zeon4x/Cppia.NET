

using Cppia.Runtime;

namespace Cppia.Instructions;

public class IfInstruction : CppiaInstruction
{
    public CppiaInstruction Condition { get; }
    public CppiaInstruction DoIf { get; }

    public IfInstruction(CppiaFile file, CppiaReader reader)
    {
        Condition = ReadInstruction(file, reader);
        DoIf = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {
        if(Condition.Execute(context) is not bool condition)
            return new NullReferenceException("Cannot check null condition");
        
        if(condition)
            return DoIf.Execute(context);
        return null;
    }
}