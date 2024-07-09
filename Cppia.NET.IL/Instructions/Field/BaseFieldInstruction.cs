using System.Collections;
using System.Reflection;


namespace Cppia.NET.Instructions;

public abstract class BaseFieldInstruction : CppiaInstruction
{
    public string Class { get; }
    public string Field { get; }
    public CppiaInstruction? Object { get; }

    public BaseFieldInstruction(CppiaFile file, CppiaReader reader, bool hasObject)
    {
        Class = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
        if(hasObject)
            Object = ReadInstruction(file, reader);
    }
}