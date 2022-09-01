

using Cppia.Runtime;

namespace Cppia.Instructions;

public class IsNotNullInstruction : CppiaValueInstruction
{
    public IsNotNullInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object? Execute(Context context)
    {
        return Value.Execute(context) is not null;
    }
}