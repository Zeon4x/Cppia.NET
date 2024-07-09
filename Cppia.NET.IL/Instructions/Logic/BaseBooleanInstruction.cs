using Cppia.NET.Instructions;


namespace Cppia.NET.Instructions;

public class BaseBooleanInstruction : BinOperationInstruction
{
    public BaseBooleanInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    

    public virtual object Compute(bool left, bool right) => throw new NotImplementedException();
}
