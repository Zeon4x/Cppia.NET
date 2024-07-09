using System.Globalization;

namespace Cppia.NET.Instructions;

public class ConstFloatInstruction : BaseConstInstruction
{
    public ConstFloatInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) {}

    protected override object? ReadValue(CppiaFile file, CppiaReader reader)
    {
        string value = file.Strings[reader.ReadInt()];
        return double.Parse(value, CultureInfo.InvariantCulture);
    }
}