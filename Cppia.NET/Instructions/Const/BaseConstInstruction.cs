

using Cppia.Runtime;

namespace Cppia.Instructions;

public abstract class BaseConstInstruction : CppiaInstruction
{
    public object? Value { get; }

    public BaseConstInstruction(CppiaFile file, CppiaReader reader)
        => Value = ReadValue(file, reader);

    protected abstract object? ReadValue(CppiaFile file, CppiaReader reader);

    public override object? Execute(Context context) => Value;
}