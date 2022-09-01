

namespace Cppia.Instructions;

public class ConstIntInstruction : BaseConstInstruction
{
    public ConstIntInstruction(CppiaFile file, CppiaReader reader) 
    : base(file, reader){}

    protected override object? ReadValue(CppiaFile file, CppiaReader reader)
    {
        return reader.ReadInt();
    }
}