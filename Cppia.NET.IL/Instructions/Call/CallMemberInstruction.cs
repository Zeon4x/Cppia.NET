using System.Reflection;


namespace Cppia.NET.Instructions;

public class CallMemberInstruction : BaseCallInstruction
{
    public string ClassName { get; }
    public string FieldName { get; }
    public CppiaInstruction ThisInstruction { get; }

    public CallMemberInstruction(CppiaFile file, CppiaReader reader)
    {
        ClassName = file.Types[reader.ReadInt()];
        FieldName = file.Strings[reader.ReadInt()];
        int argsCount = reader.ReadInt();
        ThisInstruction = ReadInstruction(file, reader);
        ReadArguments(file, reader, argsCount);
    }

    
}