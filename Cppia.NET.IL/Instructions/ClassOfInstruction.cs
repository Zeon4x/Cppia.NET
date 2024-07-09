

namespace Cppia.NET.Instructions;

public class ClassOfInstruction : CppiaInstruction
{
    public string Class { get; }
    public ClassOfInstruction(CppiaFile file, CppiaReader reader) 
    {
        Class = file.Types[reader.ReadInt()];
    }

    
}