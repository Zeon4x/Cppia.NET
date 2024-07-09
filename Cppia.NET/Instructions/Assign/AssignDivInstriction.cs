

namespace Cppia.Instructions;

public class AssignDivInstruction : BaseAssignInstruction
{
    public AssignDivInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    protected override double Assign(double currentValue, double value)
        => currentValue / value;
}