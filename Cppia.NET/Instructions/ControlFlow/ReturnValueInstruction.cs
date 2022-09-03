
using Cppia.Runtime;

namespace Cppia.Instructions;

public class ReturnValueInstruction : ReturnInstruction
{
    public CppiaInstruction Value { get; }
    
    public ReturnValueInstruction(CppiaFile file, CppiaReader reader) 
    {
        int type = reader.ReadInt();
        Value = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {
        return new ReturnResult(Value.Execute(context));
    }
}