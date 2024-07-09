



namespace Cppia.NET.Instructions;

public abstract class CrementInstruction : CppiaInstruction
{
    public CppiaInstruction Value { get; }
    public CrementInstruction(CppiaFile file, CppiaReader reader)
    {
        Value = ReadInstruction(file, reader);
    }

    

}