
using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class ReturnInstruction : CppiaInstruction
{
    public override object? Emit(ILProcessor processor, Context context)
    {
        processor.Emit(OpCodes.Ret);
        return null;
    }
}