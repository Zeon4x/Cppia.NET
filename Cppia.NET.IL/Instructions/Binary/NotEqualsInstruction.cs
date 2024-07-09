namespace Cppia.NET.Instructions;

public class NotEqualsInstruction : BinOperationInstruction
{
    public NotEqualsInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object Compute(double left, double right)
    {
        return left != right;
    }
}