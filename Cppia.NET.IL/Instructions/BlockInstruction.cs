

namespace Cppia.NET.Instructions;

public class BlockInstruction : CppiaInstruction
{
    public List<CppiaInstruction> Instructions { get; } = new();
    public BlockInstruction(CppiaFile file, CppiaReader reader)
    {
        ReadInstructions(Instructions,file,reader, reader.ReadByte());
    }

    public override object? Emit(Mono.Cecil.Cil.ILProcessor processor, Context context)
    {
        Instructions.ForEach(i => i.Emit(processor, context));
        return null;
    }
}