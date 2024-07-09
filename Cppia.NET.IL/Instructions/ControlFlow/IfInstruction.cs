



using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class IfInstruction : CppiaInstruction
{
    public CppiaInstruction Condition { get; }
    public CppiaInstruction DoIf { get; }

    public IfInstruction(CppiaFile file, CppiaReader reader)
    {
        Condition = ReadInstruction(file, reader);
        DoIf = ReadInstruction(file, reader);
    }
}