namespace Cppia.Instructions;

public class BoolOrInstruction : BaseBooleanInstruction
{
    public BoolOrInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    public override object Compute(bool left, bool right)
    {
        return left || right;
    }
}