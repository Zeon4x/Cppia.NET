using Cppia.NET.Instructions;
namespace Cppia;

public class CppiaArgument : CppiaLocalVarible
{
    public bool HasDefaultValue { get; }

    public BaseConstInstruction? DefaultValue { get; }

    public CppiaArgument(CppiaFile file, CppiaReader reader)
        : base(file, reader)
    {
        HasDefaultValue = reader.ReadBoolean();
        if (HasDefaultValue)
        {
            DefaultValue = (BaseConstInstruction)CppiaInstruction.ReadInstruction(file, reader);
        }
    }
}