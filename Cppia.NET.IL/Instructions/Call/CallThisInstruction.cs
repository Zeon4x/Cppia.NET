namespace Cppia.NET.Instructions;

public class CallThisInstruction : CallSuperInstruction
{
    public CallThisInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}
}