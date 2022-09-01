namespace Cppia.Instructions;

public class SetInstruction : BaseAssignInstruction
{
    public SetInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    protected override object? Assign(object? currentValue, object? value)
    {
        return value;
    }
}