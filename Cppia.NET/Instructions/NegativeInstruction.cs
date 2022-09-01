using Cppia.Runtime;

namespace Cppia.Instructions;

public class NegativeInstruction : CppiaValueInstruction
{
    public NegativeInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    public override object? Execute(Context context)
    {
        return -Convert.ToDouble(Value.Execute(context));
    }
}