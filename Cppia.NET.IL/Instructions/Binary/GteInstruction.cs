namespace Cppia.NET.Instructions;

public class GteInstruction : BinOperationInstruction
{
    public GteInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object Compute(double left, double right)
    {
        return left >= right;
    }
}