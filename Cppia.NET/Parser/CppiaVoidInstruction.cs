using Cppia.Instructions;
using Cppia.Runtime;

public class CppiaVoidInstruction : CppiaInstruction
{
    public override object? Execute(Context context)
    {
        Execute();
        return null;
    }

    protected virtual void Execute() => throw new NotImplementedException();
}