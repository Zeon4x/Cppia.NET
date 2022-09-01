

using Cppia.Runtime;

namespace Cppia.Instructions;

public class IsNullInstruction : CppiaValueInstruction
{
    public IsNullInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    public override object? Execute(Context context)
    {
        return Value.Execute(context) is null;
    }
}