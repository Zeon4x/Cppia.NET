

using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class ConstIntInstruction : CppiaInstruction
{
    private readonly int _value;
    public ConstIntInstruction(CppiaReader reader) 
        => _value = reader.ReadInt();

    public override object? Emit(Mono.Cecil.Cil.ILProcessor processor, Context context)
    {
        processor.Emit(OpCodes.Ldc_I4, _value);
        return context.ResolveType("int");
    }
}