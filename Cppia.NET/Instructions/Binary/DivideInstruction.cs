namespace Cppia.Instructions;

public class DivideInstruction : BinOperationInstruction
{
    public DivideInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    public override object Compute(double left, double right)
    {
        return left / right;
    }
}