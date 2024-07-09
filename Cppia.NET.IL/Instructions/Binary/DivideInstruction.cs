using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class DivideInstruction : BinOperationInstruction
{
    public DivideInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    public override void Emit(ILProcessor processor) => processor.Emit(OpCodes.Div);
}