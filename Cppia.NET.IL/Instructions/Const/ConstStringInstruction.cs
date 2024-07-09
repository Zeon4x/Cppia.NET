using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class ConstStringInstruction : CppiaInstruction
{
    private readonly string _value;

    public ConstStringInstruction(CppiaFile file, CppiaReader reader)
        => _value = file.Strings[reader.ReadInt()];


    public override object? Emit(ILProcessor processor, Context context)
    {
        processor.Emit(OpCodes.Ldstr, _value);
        return context.ResolveType("String");
    }
}