

namespace Cppia.NET.Instructions;

public class ForInstruction : CppiaInstruction
{
    public CppiaLocalVarible Varible { get; }
    public CppiaInstruction Init { get; }
    public CppiaInstruction LoopBody { get; }

    public ForInstruction(CppiaFile file, CppiaReader reader) 
    {
        Varible = new CppiaLocalVarible(file, reader);
        Init = ReadInstruction(file, reader);
        LoopBody = ReadInstruction(file, reader);
    }
}