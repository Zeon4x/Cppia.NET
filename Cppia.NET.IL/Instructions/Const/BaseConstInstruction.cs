



namespace Cppia.NET.Instructions;

public abstract class BaseConstInstruction : CppiaInstruction
{
    public object? Value { get; }

    public BaseConstInstruction(CppiaFile file, CppiaReader reader)
        => Value = ReadValue(file, reader);

    protected abstract object? ReadValue(CppiaFile file, CppiaReader reader);

    
}