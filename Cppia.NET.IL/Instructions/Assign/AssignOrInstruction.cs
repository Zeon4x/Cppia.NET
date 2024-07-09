namespace Cppia.NET.Instructions;

public class AssignOrInstruction : SetInstruction
{
    public AssignOrInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}
}