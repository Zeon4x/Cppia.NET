

namespace Cppia.NET.Instructions;

public class WhileInstruction : CppiaInstruction
{
    public bool IsWhileDo { get; }
    public CppiaInstruction Condition { get; }
    public CppiaInstruction LoopBody { get; }

    public WhileInstruction(CppiaFile file, CppiaReader reader)
    {
        IsWhileDo = reader.ReadBoolean();
        Condition = ReadInstruction(file, reader);
        LoopBody = ReadInstruction(file, reader);
    }

    
}