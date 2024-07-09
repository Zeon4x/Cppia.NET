using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class AddInstruction : BinOperationInstruction
{
    public AddInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    public override void Emit(ILProcessor processor) => processor.Emit(OpCodes.Add);
}