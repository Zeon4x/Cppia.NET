namespace Cppia.Instructions;

public class AddInstruction : BinOperationInstruction
{
    public AddInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    public override object Compute(double left, double right)
    {
        return left + right;
    }
}