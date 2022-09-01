

namespace Cppia.Instructions;

public class PostIncrInstruction : CrementInstruction
{
    public PostIncrInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    protected override double Execute(ref double value)
    {
        return value++;
    }
}