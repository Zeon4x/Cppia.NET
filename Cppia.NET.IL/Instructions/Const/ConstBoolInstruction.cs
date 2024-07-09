

namespace Cppia.NET.Instructions;

public class ConstBoolInstruction : CppiaInstruction
{
    private readonly bool _value;
    public ConstBoolInstruction(CppiaFile file, CppiaReader reader, bool value)
        => _value = value;

    
}