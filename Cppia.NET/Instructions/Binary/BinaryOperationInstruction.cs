

using Cppia.Runtime;

namespace Cppia.Instructions;

public abstract class BinOperationInstruction : CppiaInstruction
{
    public CppiaInstruction Left { get; }
    public CppiaInstruction Right { get; }

    public BinOperationInstruction(CppiaFile file, CppiaReader reader)
    {
        Left = ReadInstruction(file, reader);
        Right = ReadInstruction(file, reader);
    }

    public virtual object Compute(double left, double right) => throw new NotImplementedException();

    public override object? Execute(Context context)
    {
        double left = Convert.ToDouble(Left.Execute(context));
        double right = Convert.ToDouble(Right.Execute(context));
        return Compute(left, right);
    }
}