



using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class VaribleInstruction : CppiaInstruction
{
    public int VaribleId { get; }
    
    public VaribleInstruction(CppiaFile file, CppiaReader reader)
    {
        VaribleId = reader.ReadInt();
    }

    public override object? Emit(ILProcessor processor, Context context)
    {
        var index = context.VariblesMap.IndexOf(VaribleId);
        if (index != -1)
        {
            processor.Emit(OpCodes.Ldloc, index);
            return context.VaribleTypes[VaribleId];
        }
        throw new Exception($"Varible with key {VaribleId} not found.");
    }
}