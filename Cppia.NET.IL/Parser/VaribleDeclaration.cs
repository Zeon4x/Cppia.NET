using Mono.Cecil.Cil;
using System;

namespace Cppia.NET.Instructions;

public class VaribleDeclaration : CppiaInstruction
{
    public CppiaLocalVarible Varible { get; }
    public CppiaInstruction? Init { get; }

    public VaribleDeclaration(CppiaFile file, CppiaReader reader, bool initialize)
    {
        Varible = new CppiaLocalVarible(file, reader);
        if (initialize)
        {
            int type = reader.ReadInt();
            Init = ReadInstruction(file, reader);
        }
    }

    internal void Emit(int v, ILProcessor processor, Context context)
    {
        Init?.Emit(processor, context);
        processor.Emit(OpCodes.Stloc, context.VariblesMap.IndexOf(Varible.Id));
    }
}