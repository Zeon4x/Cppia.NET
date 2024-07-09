

namespace Cppia.Instructions;

public class AssignBoolAndInstruction : BaseAssignInstruction
{
    public AssignBoolAndInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    protected override object? Assign(object? currentValue, object? value)
        => Convert.ToBoolean(currentValue) && Convert.ToBoolean(value);
}