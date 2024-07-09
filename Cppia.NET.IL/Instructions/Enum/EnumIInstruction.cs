

namespace Cppia.NET.Instructions;

public class EnumIInstruction : CppiaInstruction
{
    public string Class { get; }
    public int Index { get; }
    public CppiaInstruction Object { get; }

    public EnumIInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        Index = reader.ReadInt();
        Object = ReadInstruction(file, reader);
    }

    
}