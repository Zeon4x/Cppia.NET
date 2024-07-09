namespace Cppia.NET.Instructions;

public class ToInterfaceInstruction : CppiaInstruction
{
    public string ToType { get; }
    public bool Array { get; }
    public string? FromType { get; }
    public CppiaInstruction Value { get; }

    public ToInterfaceInstruction(CppiaFile file, CppiaReader reader, bool inArray)
    {
        ToType = file.Types[reader.ReadInt()];
        Array = inArray;
        if(!inArray)
            FromType = file.Types[reader.ReadInt()];
        Value = ReadInstruction(file, reader);
    }
}