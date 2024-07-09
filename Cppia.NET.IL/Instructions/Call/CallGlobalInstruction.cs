

namespace Cppia.NET.Instructions;

public class CallGlobalInstruction : BaseCallInstruction
{
    public string Field { get; }
    
    public CallGlobalInstruction(CppiaFile file, CppiaReader reader)
    {
        Field = file.Strings[reader.ReadInt()];
        ReadArguments(file, reader);
    }

    
}