



namespace Cppia.NET.Instructions;

public class NewInstruction : BaseCallInstruction
{
    public string ClassName { get; }

    public NewInstruction(CppiaFile file, CppiaReader reader)
    {
        ClassName = file.Types[reader.ReadInt()];
        ReadArguments(file, reader);
    }

    
}