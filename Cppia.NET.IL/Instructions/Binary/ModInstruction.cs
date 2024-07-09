namespace Cppia.NET.Instructions;

public class ModInstruction : BinOperationInstruction
{
    public ModInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object Compute(double left, double right)
    {
        return left % right;
    }
}