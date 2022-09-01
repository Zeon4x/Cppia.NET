using Cppia.Runtime;

namespace Cppia.Instructions;

public class ContinueInstruction : CppiaInstruction
{
    public override object? Execute(Context context) => this;
}