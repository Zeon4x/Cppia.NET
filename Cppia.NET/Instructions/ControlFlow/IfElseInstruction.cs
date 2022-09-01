

using Cppia.Runtime;

namespace Cppia.Instructions;

public class IfElseInstruction : IfInstruction
{
    public CppiaInstruction DoElse { get; }
    public IfElseInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader)
    {
        DoElse = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {
        if(Condition.Execute(context) is not bool condition)
            return new NullReferenceException("Cannot check null condition");
        
        if(condition)
            return DoIf.Execute(context);
        return DoElse.Execute(context);
        
    }
}