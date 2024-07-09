using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class MultiplyInstruction : BinOperationInstruction
{
    public MultiplyInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override void Emit(ILProcessor processor) => processor.Emit(OpCodes.Mul);
}