namespace Cppia.Instructions;

public class MultiplyInstruction : BinOperationInstruction
{
    public MultiplyInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object Compute(double left, double right)
    {
        return left * right;
    }
}