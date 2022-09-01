

using Cppia.Runtime;

namespace Cppia.Instructions;

public class EnumFieldInstruction : BaseCallInstruction
{
    public string Enum { get; }
    public string Field { get; }

    public EnumFieldInstruction(CppiaFile file, CppiaReader reader, bool withArgs)
    {
        Enum = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
        if(withArgs)
            ReadArguments(file, reader);
    }

    public override object? Execute(Context context)
    {
        if(context.Runtime.GetEnum(Enum) is not CppiaEnum @enum)
            throw new Exception("Enum not found " + Enum);
        if(@enum.GetConstructor(Field) is not CppiaEnumConstructor constructor)
            throw new Exception($"Constructor {Field} not found in enum " + Enum);
        var index = @enum.Constructors.IndexOf(constructor);
        var value = new EnumValue(@enum, index, constructor, GetArguments(context));
        return value;
    }
}