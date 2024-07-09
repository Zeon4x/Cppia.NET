

using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class ReturnValueInstruction : ReturnInstruction
{
    public CppiaInstruction Value { get; }
    
    public ReturnValueInstruction(CppiaFile file, CppiaReader reader) 
    {
        int type = reader.ReadInt();
        Value = ReadInstruction(file, reader);
    }

    public override object? Emit(ILProcessor processor, Context context)
    {
        Value.Emit(processor, context);
        return base.Emit(processor, context);
    }
}