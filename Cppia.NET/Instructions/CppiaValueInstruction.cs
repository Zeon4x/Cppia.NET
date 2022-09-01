namespace Cppia.Instructions;

public class CppiaValueInstruction : CppiaInstruction
{
    public CppiaInstruction Value { get; }
    public CppiaValueInstruction(CppiaFile file, CppiaReader reader)
    {
        Value = ReadInstruction(file, reader);
    }
}