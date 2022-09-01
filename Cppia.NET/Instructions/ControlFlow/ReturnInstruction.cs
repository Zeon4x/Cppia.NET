using Cppia.NET;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class ReturnInstruction : CppiaInstruction
{
    public override object? Execute(Context context) { return new ReturnResult(); }
}