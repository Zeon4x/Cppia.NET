using Cppia.NET.Cppia.Instructions.Logic;

namespace Cppia.Instructions;

public class BoolAndInstruction : BaseBooleanInstruction
{
    public BoolAndInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    public override object Compute(bool left, bool right)
    {
        return left && right;
    }
}