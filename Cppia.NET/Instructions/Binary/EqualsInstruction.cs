

using Cppia.Runtime;

namespace Cppia.Instructions;

public class EqualsInstruction : BinOperationInstruction
{
    public EqualsInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object? Execute(Context context)
    {
        object? left = Left.Execute(context);
        object? right = Right.Execute(context);
        if(left == null && right == null)
            return true;
        if(left == null || right == null)
            return false;
        if(double.TryParse(left.ToString(), out double dleft) && double.TryParse(right.ToString(), out double dright))
            return dleft == dright;
        return left.Equals(right);
    }

}