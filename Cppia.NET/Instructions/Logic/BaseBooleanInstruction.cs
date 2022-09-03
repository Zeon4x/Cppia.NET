using Cppia.Instructions;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class BaseBooleanInstruction : BinOperationInstruction
{
    public BaseBooleanInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    public override object? Execute(Context context)
    {
        object? leftObject = Left.Execute(context);
        object? rightObject = Right.Execute(context);

        if(leftObject is not bool left || rightObject is not bool right)
            return false;

        return Compute(left, right);
    }

    public virtual object Compute(bool left, bool right) => throw new NotImplementedException();
}
