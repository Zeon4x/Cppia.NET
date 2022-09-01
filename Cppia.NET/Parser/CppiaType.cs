namespace Cppia;

public class CppiaType
{
    public string Name { get; }
    public string? Super { get; }

    public List<CppiaField> Fields { get; } = new();

    public List<string> Implements { get; } = new();

    public CppiaType(CppiaFile file, CppiaReader reader, bool hasSuper)
    {
        Name = file.Types[reader.ReadInt()];
        if(hasSuper)
            Super = file.Types[reader.ReadInt()];
    }

    protected void ReadInterfaces(CppiaFile file, CppiaReader reader)
    {
        var implementsCount = reader.ReadByte();
        for (int i = 0; i < implementsCount; i++)
            Implements.Add(file.Types[reader.ReadInt()]);
    }

    protected void ReadFields(CppiaFile file, CppiaReader reader, bool isClass)
    {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++)
        {
            if(ReadField(file, reader, isClass) is CppiaField field)
                Fields.Add(field);
        }
    }

    private CppiaField? ReadField(CppiaFile file, CppiaReader reader, bool isClass)
    {
        var code = (CppiaOpCode)reader.ReadByte();
        return code switch
        {
            CppiaOpCode.IaFunction => new CppiaMethod(file, reader, isClass),
            CppiaOpCode.IaVar => new CppiaVarible(file, reader),
            CppiaOpCode.IaImplDynamic => null,
            CppiaOpCode.IaInline => null,
            _ => throw new InvalidDataException($"Invalid field code: {code}")
        };
    }


}