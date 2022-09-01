namespace Cppia.Instructions;

public class SubdivideInstruction : BinOperationInstruction
{
    public SubdivideInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    public override object Compute(double left, double right)
    {
        return left - right;
    }
}