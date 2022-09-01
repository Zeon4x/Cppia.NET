namespace Cppia.Instructions;

public class ConstBoolInstruction : BaseConstInstruction
{
    private readonly bool _value;
    public ConstBoolInstruction(CppiaFile file, CppiaReader reader, bool value)
        : base(file, reader) => _value = value;

    protected override object? ReadValue(CppiaFile file, CppiaReader reader)
    {
        return _value;
    }
}