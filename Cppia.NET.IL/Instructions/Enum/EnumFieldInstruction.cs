



namespace Cppia.NET.Instructions;

public class EnumFieldInstruction : BaseCallInstruction
{
    public string Enum { get; }
    public string Field { get; }

    public EnumFieldInstruction(CppiaFile file, CppiaReader reader, bool withArgs)
    {
        Enum = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
        if(withArgs)
            ReadArguments(file, reader);
    }

    
}