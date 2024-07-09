using Cppia.NET.Instructions;

namespace Cppia;

public class CppiaEnum : CppiaType
{
    public List<CppiaEnumConstructor> Constructors { get; } = new();
    public CppiaInstruction? Meta { get; }
    public CppiaEnum(CppiaFile file, CppiaReader reader) 
        : base(file, reader, false)
    {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++)
            Constructors.Add(new CppiaEnumConstructor(file, reader));
        if(reader.ReadBoolean())
            Meta = CppiaInstruction.ReadInstruction(file, reader);
    }

    public CppiaEnumConstructor? GetConstructor(string name)
    {
        return Constructors.FirstOrDefault(c => c.Name == name);
    }
}