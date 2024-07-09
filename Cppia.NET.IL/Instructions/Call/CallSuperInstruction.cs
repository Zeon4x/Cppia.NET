

namespace Cppia.NET.Instructions;

public class CallSuperInstruction : BaseCallInstruction
{
    public string Class { get; }
    public string Field { get; }

    public CallSuperInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
        int argsCount = reader.ReadInt();
        ReadArguments(file, reader, argsCount);
    }

    
}