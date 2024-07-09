

namespace Cppia.NET.Instructions;

public class ArrayDefInstruction : CppiaInstruction
{
    public string Class { get; }
    public List<CppiaInstruction> Elements { get; } = new();

    public ArrayDefInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        ReadInstructions(Elements, file, reader, reader.ReadInt());
    }

     
}