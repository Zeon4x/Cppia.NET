namespace Cppia.Instructions;

public class PreincrInstruction : CrementInstruction
{
    public PreincrInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader) {}

    protected override double Execute(ref double value)
    {
        return ++value;
    }
}