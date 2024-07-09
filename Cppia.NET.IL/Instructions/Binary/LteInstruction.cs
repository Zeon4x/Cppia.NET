namespace Cppia.NET.Instructions;

public class LteInstruction : BinOperationInstruction
{
    public LteInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object Compute(double left, double right)
    {
        return left <= right;
    }
}