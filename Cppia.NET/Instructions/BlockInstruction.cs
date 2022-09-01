using Cppia.Runtime;

namespace Cppia.Instructions;

public class BlockInstruction : CppiaInstruction
{
    public List<CppiaInstruction> Instructions { get; } = new();
    public BlockInstruction(CppiaFile file, CppiaReader reader)
    {
        ReadInstructions(Instructions,file,reader, reader.ReadByte());
    }

    public override object? Execute(Context context)
    {
        foreach (CppiaInstruction instruction in Instructions)
        {
            object? value = instruction.Execute(context);
            if(value is ReturnResult result)
                return result;
            if(value is BreakInstruction breakInstruction)
                return breakInstruction;
        }
        return null;
    }
}