



namespace Cppia.NET.Instructions;

public class ObjectDefInstruction : CppiaInstruction
{
    public List<string> Fields { get; } = new();
    public List<CppiaInstruction> Values { get; } = new();

    public ObjectDefInstruction(CppiaFile file, CppiaReader reader)
    {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++)
            Fields.Add(file.Strings[reader.ReadInt()]);
        ReadInstructions(Values, file, reader, count);
    }

    
}