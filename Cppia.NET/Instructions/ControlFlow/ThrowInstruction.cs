using Cppia.Runtime;

namespace Cppia.Instructions;

public class ThrowInstruction : CppiaValueInstruction
{
    public ThrowInstruction(CppiaFile file, CppiaReader reader) 
        :base(file,reader){}

    public override object? Execute(Context context)
    {
        if(Value.Execute(context) is not CppiaException exception)
            throw new Exception("Cannot throw null");
        throw exception;
    }
}