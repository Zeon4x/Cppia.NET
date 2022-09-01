

namespace Cppia.Instructions;

public class PostDecrInstruction : CrementInstruction
{
    public PostDecrInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    protected override double Execute(ref double value)
    {
        return value--;
    }

}