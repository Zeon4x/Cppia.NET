using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class SubdivideInstruction : BinOperationInstruction
{
    public SubdivideInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    public override void Emit(ILProcessor processor) => processor.Emit(OpCodes.Sub);
}