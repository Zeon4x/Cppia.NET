namespace Cppia.Instructions;

public class LtInstruction : BinOperationInstruction
{
    public LtInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object Compute(double left, double right)
    {
        return left < right;
    }
}