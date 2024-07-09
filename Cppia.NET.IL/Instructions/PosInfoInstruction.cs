using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Cppia.NET.Instructions;

public class PosInfoInstruction : CppiaInstruction
{
    public PosInfo PosInfo { get; }

    public PosInfoInstruction(CppiaFile file, CppiaReader reader)
    {
        PosInfo = new(
            file: file.Strings[reader.ReadInt()],
            line: reader.ReadInt(),
            @class: file.Strings[reader.ReadInt()],
            method: file.Strings[reader.ReadInt()]
        );
    }

    public override object? Emit(ILProcessor processor, Context context)
    {
        var reference = context.Module.ImportReference(typeof(PosInfo)).Resolve();
        var constructor = context.Module.ImportReference(reference.GetConstructors().First());
        processor.Emit(OpCodes.Ldstr, PosInfo.File);
        processor.Emit(OpCodes.Ldc_I4, PosInfo.Line);
        processor.Emit(OpCodes.Ldstr, PosInfo.Class);
        processor.Emit(OpCodes.Ldstr, PosInfo.Method);
        processor.Emit(OpCodes.Newobj, constructor);
        return null;
    }

    
}