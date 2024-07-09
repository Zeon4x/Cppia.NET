using Cppia.Runtime;

namespace Cppia.Instructions;

public class ConstThisInstruction : CppiaInstruction 
{
    public override object? Execute(Context context) => context.This;
}