



namespace Cppia.NET.Instructions;

public class IfElseInstruction : IfInstruction
{
    public CppiaInstruction DoElse { get; }
    public IfElseInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader)
    {
        DoElse = ReadInstruction(file, reader);
    }

    
}