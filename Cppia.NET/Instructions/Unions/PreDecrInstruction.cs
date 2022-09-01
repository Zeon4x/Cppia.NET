namespace Cppia.Instructions;

public class PreDecrInstruction : CrementInstruction
{
    public PreDecrInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    protected override double Execute(ref double value)
    {
        return --value;
    }
}