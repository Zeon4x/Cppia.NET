using Cppia.Runtime;

namespace Cppia.Instructions;

public class EnumIInstruction : CppiaInstruction
{
    public string Class { get; }
    public int Index { get; }
    public CppiaInstruction Object { get; }

    public EnumIInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        Index = reader.ReadInt();
        Object = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {
        if(Object.Execute(context) is not EnumValue enumValue)
            throw new Exception("Cannot get enum item of null");

        return enumValue.Properties[Index];
    }
}