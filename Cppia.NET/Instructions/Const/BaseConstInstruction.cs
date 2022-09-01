

using Cppia.Runtime;

namespace Cppia.Instructions;

public class BaseConstInstruction : CppiaInstruction
{
    public object? Value { get; }

    public BaseConstInstruction(CppiaFile file, CppiaReader reader)
        => Value = ReadValue(file, reader);

    protected virtual object? ReadValue(CppiaFile file, CppiaReader reader) => null;

    public override object? Execute(Context context)
    {
        return Value;
    }
}