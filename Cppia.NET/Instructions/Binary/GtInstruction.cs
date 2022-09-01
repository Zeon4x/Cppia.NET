using Cppia;
using Cppia.Instructions;

public class GtInstruction : BinOperationInstruction
{
    public GtInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    public override object Compute(double left, double right)
    {
        return left > right;
    }
}