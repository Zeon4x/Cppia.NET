

using Cppia.Runtime;

namespace Cppia.Instructions;

public class LogicNotInstruction : CppiaValueInstruction
{
    public LogicNotInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    public override object? Execute(Context context)
    {
        if(Value.Execute(context) is not bool value)
            throw new InvalidOperationException("Expected bool varible");
        return !value;
    }
}