

namespace Cppia.Instructions;

public class AssignAddInstruction : BaseAssignInstruction
{
    public AssignAddInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    protected override double Assign(double currentValue, double value)
        => currentValue + value;
}