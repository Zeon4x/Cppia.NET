

using Cppia.Runtime;

namespace Cppia.Instructions
{
    public class BreakInstruction : CppiaInstruction 
    {
        public override object? Execute(Context context) => this;
    }
}