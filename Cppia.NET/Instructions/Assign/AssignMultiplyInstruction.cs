

namespace Cppia.Instructions;

public class AssignMulInstruction : BaseAssignInstruction
{
    public AssignMulInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    protected override double Assign(double currentValue, double value)
    {
        return currentValue * value;
    }
}