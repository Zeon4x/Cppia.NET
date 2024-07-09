using Cppia.Runtime;

namespace Cppia.Instructions;

public class ConstNullInstruction : CppiaInstruction
{
    public override object? Execute(Context context) => null;
}